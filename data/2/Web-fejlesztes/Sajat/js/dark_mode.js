document.addEventListener('DOMContentLoaded', function () {
    const toggle = document.getElementById('darkModeToggle');

    toggle.addEventListener('change', function () {
        document.body.classList.toggle('dark_mode');
        
        const kisbetusreszElements = document.querySelectorAll('p.kisbetusresz');
        kisbetusreszElements.forEach(function (element) {
            element.classList.toggle('dark_mode');
        });

        const BekuldesElements = document.querySelectorAll('div.darkish');
        BekuldesElements.forEach(function (element) {
            element.classList.toggle('dark_mode');
        });
    });
});
