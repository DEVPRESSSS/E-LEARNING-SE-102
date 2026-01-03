

// HOME/INDEX MENU ACTIVE CSS

document.querySelectorAll('.course-navigation').forEach(el => {
    el.addEventListener('click', function (e) {
        e.preventDefault();

        document.querySelectorAll('.course-menu a')
            .forEach(a => a.classList.remove('active'));

        this.classList.add('active');

        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            target.scrollIntoView({ behavior: 'smooth' });
        }
    });
});

