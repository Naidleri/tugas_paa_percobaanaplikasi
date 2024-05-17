document.addEventListener("DOMContentLoaded", () => {
  const apiUrl = "https://localhost:7131";
  const loginForm = document.getElementById("loginForm");

  async function handleLogin(e) {
    e.preventDefault();
    const username = loginForm.querySelector("#login-username").value;
    const password = loginForm.querySelector("#login-password").value;

    try {
      const response = await fetch(`${apiUrl}/login`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ username, password }),
      });

      if (response.ok) {
        const data = await response.json();
        localStorage.setItem("token", data.token);
        alert("Login successful!");
        loginForm.reset();
        window.location.href = "/views/pages/mainPages.html";
      } else {
        alert("Failed to login.");
      }
    } catch (error) {
      alert(`Login failed: ${error.message}`);
    }
  }

  loginForm.addEventListener("submit", handleLogin);
});
