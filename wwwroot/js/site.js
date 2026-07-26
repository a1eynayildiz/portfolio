(function () {
    // Reveal-on-scroll for cards & sections
    const els = document.querySelectorAll('.skill-card, .project-card, .timeline-item, .chip, .cta-block');
    els.forEach(el => el.classList.add('reveal'));

    if ('IntersectionObserver' in window) {
        const io = new IntersectionObserver((entries) => {
            entries.forEach(e => {
                if (e.isIntersecting) {
                    e.target.classList.add('visible');
                    io.unobserve(e.target);
                }
            });
        }, { threshold: 0.1 });
        els.forEach(el => io.observe(el));
    } else {
        els.forEach(el => el.classList.add('visible'));
    }

    // Close mobile menu when link clicked
    document.querySelectorAll('.nav-links a').forEach(a => {
        a.addEventListener('click', () => {
            document.querySelector('.nav-links')?.classList.remove('open');
        });
    });
})();
