// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {
    const sidebar = document.getElementById("sidebar");
    const mainContent = document.getElementById("mainContent");
    const toggleBtn = document.getElementById("sidebarToggle");

    toggleBtn.addEventListener("click", function () {
        sidebar.classList.toggle("collapsed");
        mainContent.classList.toggle("collapsed");
        mainContent.classList.toggle("expanded");
    });
});
// Clear viền đỏ khi user nhập lại (áp dụng cho mọi form có needs-validation)
$(document).on(
  "input change",
  "form.needs-validation input, form.needs-validation select, form.needs-validation textarea",
  function () {
    const input = $(this);

    if (input.valid()) {
      input.removeClass("is-invalid").addClass("is-valid");
    } else {
      input.removeClass("is-valid");
    }
  }
);
