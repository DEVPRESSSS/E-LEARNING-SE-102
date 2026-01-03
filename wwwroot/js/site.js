// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// HOME/INDEX MENU ACTIVE CSS
    function setActive(el, e) {
        e.preventDefault();

        document.querySelectorAll('.course-menu a')
            .forEach(a => a.classList.remove('active'));

        el.classList.add('active');

        const target = document.querySelector(el.getAttribute('href'));
        if (target) {
            target.scrollIntoView({ behavior: 'smooth' });
        }
    }