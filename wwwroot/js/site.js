/* Aleyna Yıldız · Portfolyo etkileşimleri
   Harici kütüphane kullanılmaz. JavaScript kapalıyken de içerik okunabilir kalır. */
(function () {
    'use strict';

    var root = document.documentElement;
    var body = document.body;
    var header = document.querySelector('[data-header]');

    root.classList.add('js');

    /* ---------- Tema ---------- */
    var themeBtn = document.querySelector('[data-theme-toggle]');

    function applyTheme(theme, persist) {
        root.setAttribute('data-theme', theme);
        if (themeBtn) {
            themeBtn.setAttribute('aria-label', theme === 'dark' ? 'Açık temaya geç' : 'Koyu temaya geç');
        }
        if (persist) {
            try { localStorage.setItem('theme', theme); } catch (e) { /* gizli sekme vb. */ }
        }
    }

    applyTheme(root.getAttribute('data-theme') || 'light', false);

    if (themeBtn) {
        themeBtn.addEventListener('click', function () {
            applyTheme(root.getAttribute('data-theme') === 'dark' ? 'light' : 'dark', true);
        });
    }

    // Kullanıcı açıkça seçim yapmadıysa işletim sistemi teması değiştiğinde onu izle.
    window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', function (e) {
        var stored = null;
        try { stored = localStorage.getItem('theme'); } catch (err) { }
        if (!stored) applyTheme(e.matches ? 'dark' : 'light', false);
    });

    /* ---------- Kaydırma: başlık zemini ---------- */
    var ticking = false;

    function onScroll() {
        var y = window.scrollY;
        if (header) header.classList.toggle('is-scrolled', y > 16);
        ticking = false;
    }

    window.addEventListener('scroll', function () {
        if (!ticking) {
            window.requestAnimationFrame(onScroll);
            ticking = true;
        }
    }, { passive: true });
    onScroll();

    /* ---------- Mobil menü ---------- */
    var navToggle = document.querySelector('[data-nav-toggle]');
    var navLinks = document.querySelector('[data-nav-links]');

    function setMenu(open) {
        if (!navToggle || !navLinks) return;
        navToggle.setAttribute('aria-expanded', String(open));
        navToggle.setAttribute('aria-label', open ? 'Menüyü kapat' : 'Menüyü aç');
        navLinks.classList.toggle('is-open', open);
        header.classList.toggle('is-menu-open', open);
        body.classList.toggle('is-locked', open);
    }

    if (navToggle) {
        navToggle.addEventListener('click', function () {
            setMenu(navToggle.getAttribute('aria-expanded') !== 'true');
        });
        navLinks.querySelectorAll('a').forEach(function (a) {
            a.addEventListener('click', function () { setMenu(false); });
        });
        document.addEventListener('keydown', function (e) {
            if (e.key === 'Escape' && navLinks.classList.contains('is-open')) {
                setMenu(false);
                navToggle.focus();
            }
        });
        window.matchMedia('(min-width: 640px)').addEventListener('change', function (e) {
            if (e.matches) setMenu(false);
        });
    }

    /* ---------- Aktif bölüm vurgusu ---------- */
    var navMap = {};
    document.querySelectorAll('[data-nav]').forEach(function (a) {
        navMap[a.getAttribute('data-nav')] = a;
    });

    function setActive(id) {
        Object.keys(navMap).forEach(function (key) {
            var isActive = key === id;
            navMap[key].classList.toggle('is-active', isActive);
            if (isActive) navMap[key].setAttribute('aria-current', 'true');
            else navMap[key].removeAttribute('aria-current');
        });
    }

    if ('IntersectionObserver' in window) {
        var sectionObserver = new IntersectionObserver(function (entries) {
            entries.forEach(function (entry) {
                // Menüde karşılığı olmayan bölümlerde (Staj, Başarılar, İletişim) hiçbir bağlantı vurgulanmaz.
                if (entry.isIntersecting) setActive(entry.target.id);
            });
        }, { rootMargin: '-45% 0px -50% 0px' });

        document.querySelectorAll('main > section[id]').forEach(function (s) {
            sectionObserver.observe(s);
        });
    }

    /* ---------- Proje detay paneli ---------- */
    var HASH_PREFIX = '#projeler/';
    var openDialog = null;
    var lastTrigger = null;
    var pushedState = false;

    function dialogFor(slug) {
        return document.querySelector('[data-project-dialog="' + CSS.escape(slug) + '"]');
    }

    function slugFromHash() {
        var h = decodeURIComponent(window.location.hash || '');
        return h.indexOf(HASH_PREFIX) === 0 ? h.slice(HASH_PREFIX.length) : null;
    }

    function showProject(slug, options) {
        var dialog = dialogFor(slug);
        if (!dialog || typeof dialog.showModal !== 'function') return false;
        if (openDialog && openDialog !== dialog) hideProject({ fromHistory: true });

        if (options.push) {
            history.pushState({ project: slug }, '', HASH_PREFIX + slug);
            pushedState = true;
        }

        dialog.showModal();
        dialog.scrollTop = 0;
        body.classList.add('is-locked');
        openDialog = dialog;
        return true;
    }

    function hideProject(options) {
        if (!openDialog) return;
        var dialog = openDialog;
        openDialog = null;
        if (dialog.open) dialog.close();
        body.classList.remove('is-locked');

        if (!options.fromHistory) {
            if (pushedState) {
                pushedState = false;
                history.back();
            } else if (slugFromHash()) {
                // Sayfa doğrudan bir proje adresiyle açıldıysa geçmişe yeni kayıt eklemeden adresi düzelt.
                history.replaceState(null, '', '#projeler');
            }
        } else {
            pushedState = false;
        }

        if (lastTrigger) {
            lastTrigger.focus({ preventScroll: true });
            lastTrigger = null;
        }
    }

    document.querySelectorAll('[data-project-open]').forEach(function (link) {
        link.addEventListener('click', function (e) {
            if (showProject(link.getAttribute('data-project-open'), { push: true })) {
                e.preventDefault();
                lastTrigger = link;
            }
        });
    });

    document.querySelectorAll('[data-project-dialog]').forEach(function (dialog) {
        dialog.querySelector('[data-dialog-close]').addEventListener('click', function () {
            hideProject({ fromHistory: false });
        });

        // Dış alana (karartılmış zemine) tıklanınca kapanır.
        dialog.addEventListener('click', function (e) {
            if (e.target === dialog) hideProject({ fromHistory: false });
        });

        // Esc tuşu: tarayıcının varsayılan kapatmasını kendi akışımıza yönlendir.
        dialog.addEventListener('cancel', function (e) {
            e.preventDefault();
            hideProject({ fromHistory: false });
        });
    });

    window.addEventListener('popstate', function () {
        var slug = slugFromHash();
        if (slug) {
            showProject(slug, { push: false });
        } else if (openDialog) {
            hideProject({ fromHistory: true });
        }
    });

    // Sayfa "#projeler/parkpilot" gibi bir adresle açıldıysa ilgili paneli aç.
    var initialSlug = slugFromHash();
    if (initialSlug && dialogFor(initialSlug)) {
        var projectsSection = document.getElementById('projeler');
        if (projectsSection) projectsSection.scrollIntoView({ behavior: 'auto' });
        lastTrigger = document.querySelector('[data-project-open="' + CSS.escape(initialSlug) + '"]');
        showProject(initialSlug, { push: false });
    }

    /* ---------- E-posta adresini kopyalama ---------- */
    document.querySelectorAll('[data-copy]').forEach(function (btn) {
        var status = btn.closest('.card') ? btn.closest('.card').querySelector('[data-copy-status]') : null;
        btn.addEventListener('click', function () {
            var text = btn.getAttribute('data-copy');
            var done = function () {
                btn.classList.add('is-copied');
                if (status) status.textContent = 'Kopyalandı';
                window.setTimeout(function () {
                    btn.classList.remove('is-copied');
                    if (status) status.textContent = '';
                }, 2000);
            };
            if (navigator.clipboard && window.isSecureContext) {
                navigator.clipboard.writeText(text).then(done, function () {
                    if (status) status.textContent = 'Kopyalanamadı; adresi seçip kopyalayabilirsiniz.';
                });
            } else if (status) {
                status.textContent = 'Kopyalanamadı; adresi seçip kopyalayabilirsiniz.';
            }
        });
    });

    /* ---------- İletişim formu ---------- */
    var form = document.querySelector('[data-contact-form]');
    if (form) {
        var submitBtn = form.querySelector('[data-submit]');
        var submitLabel = form.querySelector('[data-submit-label]');
        var formStatus = form.querySelector('[data-form-status]');
        var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

        var rules = {
            name: function (v) {
                if (!v) return 'Lütfen adınızı ve soyadınızı yazın.';
                if (v.length < 2 || v.length > 80) return 'Ad soyad 2 ile 80 karakter arasında olmalıdır.';
                return '';
            },
            email: function (v) {
                if (!v) return 'Lütfen e-posta adresinizi yazın.';
                if (!emailPattern.test(v)) return 'Lütfen geçerli bir e-posta adresi girin.';
                return '';
            },
            subject: function (v) {
                return v ? '' : 'Lütfen bir konu seçin.';
            },
            message: function (v) {
                if (!v) return 'Lütfen mesajınızı yazın.';
                if (v.length < 10 || v.length > 2000) return 'Mesaj 10 ile 2000 karakter arasında olmalıdır.';
                return '';
            }
        };

        function fieldInput(key) {
            return form.querySelector('[name="' + key.charAt(0).toUpperCase() + key.slice(1) + '"]');
        }

        function setError(key, message) {
            var input = fieldInput(key);
            var errorEl = form.querySelector('[data-error-for="' + key + '"]');
            if (!input || !errorEl) return;
            errorEl.textContent = message || '';
            input.closest('.field').classList.toggle('has-error', !!message);
            if (message) input.setAttribute('aria-invalid', 'true');
            else input.removeAttribute('aria-invalid');
        }

        function validate() {
            var firstInvalid = null;
            Object.keys(rules).forEach(function (key) {
                var input = fieldInput(key);
                var message = rules[key](input.value.trim());
                setError(key, message);
                if (message && !firstInvalid) firstInvalid = input;
            });
            return firstInvalid;
        }

        function setStatus(message, ok) {
            formStatus.textContent = message || '';
            formStatus.classList.toggle('is-ok', !!message && ok);
            formStatus.classList.toggle('is-error', !!message && !ok);
        }

        // Kullanıcı hatalı bir alanı düzelttikçe hata mesajı kaybolur.
        Object.keys(rules).forEach(function (key) {
            var input = fieldInput(key);
            input.addEventListener('input', function () {
                if (input.closest('.field').classList.contains('has-error')) {
                    setError(key, rules[key](input.value.trim()));
                }
            });
        });

        form.addEventListener('submit', function (e) {
            e.preventDefault();
            setStatus('');

            var firstInvalid = validate();
            if (firstInvalid) {
                firstInvalid.focus();
                return;
            }

            submitBtn.disabled = true;
            submitLabel.textContent = 'Gönderiliyor…';

            fetch(form.action, {
                method: 'POST',
                body: new FormData(form),
                headers: { 'Accept': 'application/json' },
                credentials: 'same-origin'
            })
                .then(function (res) {
                    return res.json().catch(function () { return {}; }).then(function (data) {
                        return { status: res.status, data: data };
                    });
                })
                .then(function (result) {
                    var data = result.data || {};
                    if (result.status === 200 && data.ok) {
                        form.reset();
                        setStatus(data.message || 'Mesajınız ulaştı.', true);
                        return;
                    }
                    if (data.errors) {
                        Object.keys(data.errors).forEach(function (key) { setError(key, data.errors[key]); });
                    }
                    setStatus(data.message || 'Mesajınız gönderilemedi. Lütfen daha sonra tekrar deneyin.', false);
                })
                .catch(function () {
                    setStatus('Bağlantı kurulamadı. İnternet bağlantınızı kontrol edip tekrar deneyin.', false);
                })
                .finally(function () {
                    submitBtn.disabled = false;
                    submitLabel.textContent = 'Mesajı gönder';
                });
        });
    }
})();
