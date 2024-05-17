document.addEventListener("DOMContentLoaded", async () => {
  const apiUrl = "https://localhost:7131";

  document.getElementById("registerForm").addEventListener("submit", handleRegister);

  async function handleRegister(e) {
    e.preventDefault();
    const username = document.getElementById("register-username").value;
    const password = document.getElementById("register-password").value;

    const response = await fetch(`${apiUrl}/register`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ username, password }),
    });

    if (response.ok) {
      alert("Registration successful!");
      document.getElementById("registerForm").reset();
    } else {
      alert("Failed to register.");
    }
  }
});
