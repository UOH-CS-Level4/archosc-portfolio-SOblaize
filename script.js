const darkModeToggle = document.getElementById("darkModeToggle");

if (darkModeToggle) {
    darkModeToggle.addEventListener("click", () => {
        document.body.classList.toggle("dark-mode");
    });
}

const myTitle = document.querySelector(".title");
const myName = document.querySelector(".name");
const myDescription = document.querySelector(".description");

console.log(myTitle);
console.log(myName);
console.log(myDescription);
