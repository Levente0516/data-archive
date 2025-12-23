document.addEventListener("DOMContentLoaded", function () {
    const submitButton = document.querySelector('input[type="submit"]');
    const resetButton = document.getElementById("torol");
    const textFields = document.querySelectorAll('input[type="text"], textarea');
    const checkboxes = document.querySelectorAll('input[type="checkbox"]');
    const radioButtons = document.querySelectorAll('input[type="radio"]');

    function clearForm() {
        textFields.forEach(field => field.value = "");
        checkboxes.forEach(checkbox => checkbox.checked = false);
        radioButtons.forEach(radio => radio.checked = false);
    }

    submitButton.addEventListener("click", clearForm);
    resetButton.addEventListener("click", clearForm);
});
