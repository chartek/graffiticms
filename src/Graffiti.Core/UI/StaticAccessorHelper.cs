﻿// This file is derived from the Caste Project MonoRail Framework.
// Original License included below:
//
// Copyright 2004-2009 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using NVelocity;

namespace Graffiti.Core
{
	using System.Reflection;

	/// <summary>
	/// Provides a helper to access static operations on types to NVelocity.
	/// </summary>
	/// <typeparam name="T">the type to access</typeparam>
	public class StaticAccessorHelper<T> : NVelocity.IDuck
	{

		/// <summary>
		/// Invoke a get operation on the value type
		/// </summary>
		/// <param name="propName">the property or field to get</param>
		/// <returns>the value</returns>
		public object GetInvoke(string propName)
		{
			return typeof(T).InvokeMember(propName, BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField |BindingFlags.GetProperty, null, null, new object[] { });
		}

		/// <summary>
		/// Invoke a method on the value type
		/// </summary>
		/// <param name="method">the method name</param>
		/// <param name="args">the argumenents.</param>
		/// <returns>the result of the method invocation.</returns>
		public object Invoke(string method, params object[] args)
		{
			return typeof(T).InvokeMember(method, BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod, null, null, args);
		}

		/// <summary>
		/// Invoke a set operation on the value type
		/// </summary>
		/// <param name="propName">the property or field to set</param>
		/// <param name="value">the value to set the property or field to.</param>
		public void SetInvoke(string propName, object value)
		{
			typeof(T).InvokeMember(propName, BindingFlags.Public | BindingFlags.Static | BindingFlags.SetField | BindingFlags.SetProperty, null, null, new object[] { value });
		}

	}
}