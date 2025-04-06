﻿using Capstone.Menus;

namespace Capstone
{
	/// <summary>
	/// ExampleSumObject is an example of a business object that you can manipulate using MenuItem and ConsoleMenu
	/// Represents an example object that maintains a running total.
	/// </summary>
	internal class ExampleSumObject
	{
        public int Total { get; private set; }
        /// <summary>
        /// Gets the current total sum.
        /// </summary>
        public ExampleSumObject(int total)
		{
			Total = total;
		}
        /// <summary>
        /// Adds a specified value to the total sum.
        /// </summary>
        /// <param name="value">The value to add to the total sum.</param>
 
        public void AddToSum(int value)
		{
			Total += value;
		}
    }
}
