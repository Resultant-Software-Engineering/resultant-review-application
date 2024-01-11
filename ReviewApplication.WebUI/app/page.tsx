"use client"

import { useState } from 'react';

const LoginPage = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const handleLogin = async () => {
    // Call your API endpoint with the provided email and password
    try {
      const response = await fetch(`http://0.0.0.0:5005/api/user?userName=${encodeURIComponent(email)}&password=${encodeURIComponent(password)}`, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
      },
    });

    if (response.ok) {
      const userData = await response.json();
      
      // Extract first name and last name from the response
      const { firstName, lastName } = userData;
  
      // Redirect to another page with first name and last name as query parameters
      window.location.href = `/accounts?firstName=${encodeURIComponent(firstName)}&lastName=${encodeURIComponent(lastName)}`;
    } else {
        // Handle login error, show error message or redirect to error page
        console.error('Login failed');
      }
    } catch (error) {
      console.error('Error during login:', error);
    }
  };

  return (
    <div className="flex justify-center items-center min-h-screen">
    <div className="p-8 bg-white rounded shadow-md">
      <form>
        <label className="text-black">Email</label>
        <input
          type="text"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          className="p-2 mb-4 w-full border border-gray-300 rounded"
        />
        <br />
        <label className="text-black">Password</label>
        <input
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          className="p-2 mb-4 w-full border border-gray-300 rounded"
        />
        <br />
        <button
          type="button"
          onClick={handleLogin}
          className="p-3 bg-blue-500 text-white border-none rounded"
        >
          Log In
        </button>
      </form>
    </div>
  </div>
  );
};

export default LoginPage;
