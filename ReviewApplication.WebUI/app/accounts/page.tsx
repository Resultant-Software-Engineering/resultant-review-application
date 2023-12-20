"use client"

import React, { useEffect, useState } from 'react';
import Link from 'next/link';
import { FaArrowLeft } from 'react-icons/fa';

const getQueryParams = ()=> {
  const queryParams = {};
  const queryString = window.location.search.substring(1);
  const pairs = queryString.split('&');

  for (let i = 0; i < pairs.length; i++) {
    const pair = pairs[i].split('=');
    queryParams[pair[0]] = decodeURIComponent(pair[1] || '');
  }

  return queryParams;
};

const Accounts = () => {
  const [queryParams, setQueryParams] = useState({});
  const [accountBalance, setAccountBalance] = useState<number>(1000);
  const [transactionAmount, setTransactionAmount] = useState<string>('');

  useEffect(() => {
    if (queryParams.firstName && queryParams.lastName) {
      // Make the API call to get the actual balance
      fetch(`http://0.0.0.0:5005/api/Account/balance?userFullName=${encodeURIComponent(`${queryParams.firstName} ${queryParams.lastName}`)}`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        }
      })
        .then((response) => response.json())
        .then((data) => {
          setAccountBalance(data);
        })
        .catch((error) => {
          console.error('Error fetching balance:', error);
        });
    }
  }, [queryParams.firstName, queryParams.lastName]);


  useEffect(() => {
    // Update query params on component mount
    setQueryParams(getQueryParams());
  }, []);

  const handleDeposit = () => {
    // Dummy deposit logic, update account balance
    const depositAmount = parseFloat(transactionAmount);
    if (!isNaN(depositAmount)) {
      setAccountBalance(accountBalance + depositAmount);
    }
  };

  const handleWithdrawal = () => {
    // Dummy withdrawal logic, update account balance
    const withdrawalAmount = parseFloat(transactionAmount);
    if (!isNaN(withdrawalAmount)) {
      setAccountBalance(accountBalance - withdrawalAmount);
    }
  };

  return (
    <div className="flex flex-col items-center justify-center h-screen">
      <div className="container mx-auto p-8 bg-white shadow-md max-w-md">
        <div className="flex justify-between items-center mb-6">
          {/* Back button with arrow icon */}
         
        <Link href={"/"} className="text-blue-500 hover:underline flex items-center">
            <FaArrowLeft className="mr-2" />
        </Link>
         
          <h1 className="text-3xl font-bold">Accounts</h1>
        </div>
        <p className="mb-4">
          Hello, {queryParams.firstName || ''} {queryParams.lastName || ''}
        </p>
        <p className="mb-4">Account Balance: ${accountBalance !== null ? accountBalance : 'Loading...'}</p>
        <div className="flex space-x-4 mb-4">
          <input
            type="number"
            placeholder="Enter amount"
            value={transactionAmount}
            onChange={(e) => setTransactionAmount(e.target.value)}
            className="p-2 border border-gray-300 rounded w-1/2"
          />
          <button
            onClick={handleDeposit}
            className="bg-green-500 hover:bg-green-600 text-white py-2 px-4 rounded focus:outline-none focus:shadow-outline"
          >
            Deposit
          </button>
          <button
            onClick={handleWithdrawal}
            className="bg-red-500 hover:bg-red-600 text-white py-2 px-4 rounded focus:outline-none focus:shadow-outline"
          >
            Withdraw
          </button>
        </div>
      </div>
    </div>
  );
};

export default Accounts;
