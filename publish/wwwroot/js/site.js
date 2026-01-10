

// HOME/INDEX MENU ACTIVE CSS
document.querySelectorAll('.course-navigation').forEach(el => {
    el.addEventListener('click', function (e) {
        e.preventDefault(); // Prevent page reload

        // Remove 'active' from all links
        document.querySelectorAll('.course-menu a')
            .forEach(a => a.classList.remove('active'));

        // Add 'active' to the clicked link
        this.classList.add('active');

        // Navigate to the Razor-generated URL
        window.location.href = this.getAttribute('href');
    });
});

