

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

//LOGIN JS
const togglePassword = document.getElementById('togglePassword');
const passwordInput = document.getElementById('passwordInput');
const toggleIcon = document.getElementById('toggleIcon');

togglePassword.addEventListener('click', function() {
    const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
    passwordInput.setAttribute('type', type);
            
    // Toggle icon
    if (type === 'password') {
        toggleIcon.classList.remove('fa-eye-slash');
        toggleIcon.classList.add('fa-eye');
    } else {
        toggleIcon.classList.remove('fa-eye');
        toggleIcon.classList.add('fa-eye-slash');
    }
});

document.getElementById('loginForm').addEventListener('submit', function(e) {
    e.preventDefault();
    alert('Login functionality would be implemented here!');
});

