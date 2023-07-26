document.addEventListener("DOMContentLoaded", function () {
  const menuHamburger = document.querySelector(".burger");
  const navLinks = document.querySelector(".navbar");

  menuHamburger.addEventListener("click", () => {
    navLinks.classList.toggle("mobile-menu");
  });
});
