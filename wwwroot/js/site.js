document.addEventListener("DOMContentLoaded", function () {
    // 🔍 Search functionality
    const searchInput = document.getElementById("searchInput");
    const searchButton = document.getElementById("searchButton");
    const cards = document.querySelectorAll("#mangaGrid .card");

    function filterManga() {
        const query = searchInput.value.toLowerCase();
        cards.forEach(card => {
            const title = card.getAttribute("data-title");
            card.style.display = title.includes(query) ? "block" : "none";
        });
    }

    if (searchInput) {
        searchInput.addEventListener("input", filterManga);
    }

    if (searchButton) {
        searchButton.addEventListener("click", filterManga);
    }

    // ☰ Dropdown toggle
    const toggle = document.querySelector(".dropdown-toggle");
    const menu = document.querySelector(".dropdown-menu");

    if (toggle && menu) {
        toggle.addEventListener("click", () => {
            menu.classList.toggle("show");
        });

        document.addEventListener("click", (e) => {
            if (!toggle.contains(e.target) && !menu.contains(e.target)) {
                menu.classList.remove("show");
            }
        });
    }

    // 🌙 Theme mode switching
    const themeRadios = document.querySelectorAll("input[name='theme']");
    const body = document.body;

    function detectSystemTheme() {
        return window.matchMedia("(prefers-color-scheme: dark)").matches ? "dark" : "light";
    }

    function applyTheme(value) {
        const theme = value === "system" ? detectSystemTheme() : value;
        body.setAttribute("data-theme", theme);
        localStorage.setItem("theme", value);
    }

    themeRadios.forEach(radio => {
        radio.addEventListener("change", () => applyTheme(radio.value));
    });

    const savedTheme = localStorage.getItem("theme") || "system";
    applyTheme(savedTheme);
});