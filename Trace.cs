﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#define TRACE // Do not remove this, it is needed to retain calls to these conditional methods in release builds

using System;
#if SSHARP
using System.Linq;
using Environment = Crestron.SimplSharp.CrestronEnvironment;
using Crestron.SimplSharp;
#else
#endif

#if SSHARP
namespace SSCore.Diagnostics
#else
namespace System.Diagnostics
#endif
	{
	/// <summary>
	/// Provides a set of properties and methods for debugging code.
	/// </summary>
	public static partial class Trace
		{
		[System.Diagnostics.Conditional ("TRACE")]
		public static void Assert (bool condition)
			{
			Assert (condition, string.Empty, string.Empty);
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void Assert (bool condition, string message)
			{
			Assert (condition, message, string.Empty);
			}

		[System.Diagnostics.Conditional ("TRACE")]
#if !NETCF
        [System.Security.SecuritySafeCritical]
#endif
		public static void Assert (bool condition, string message, string detailMessage)
			{
			if (!condition)
				{
				string stackTrace = null;

#if NETCF
				try
					{
					int j = 0;
					int i = 123 / j;
					}
				catch (DivideByZeroException dex)
					{
					stackTrace = String.Join ("\r\n", dex.StackTrace.Replace ("\r\n", "\n").Split ('\n').Skip (1).ToArray ());
					}
#else
                try
                {
                    stackTrace = Environment.StackTrace;
                }
                catch
                {
                    stackTrace = "";
                }
#endif

				WriteLine (FormatAssert (stackTrace, message, detailMessage));
				s_logger.ShowAssertDialog (stackTrace, message, detailMessage);
				}
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void Fail (string message)
			{
			Assert (false, message, string.Empty);
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void Fail (string message, string detailMessage)
			{
			Assert (false, message, detailMessage);
			}

		private static string FormatAssert (string stackTrace, string message, string detailMessage)
			{
			return "---- TRACE ASSERTION FAILED ----" + Environment.NewLine
						  + "---- Assert Short Message ----" + Environment.NewLine
						  + message + Environment.NewLine
						  + "---- Assert Long Message ----" + Environment.NewLine
						  + detailMessage + Environment.NewLine
						  + stackTrace;
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void Assert (bool condition, string message, string detailMessageFormat, params object[] args)
			{
			Assert (condition, message, string.Format (detailMessageFormat, args));
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void WriteLine (string message)
			{
			Write (message + Environment.NewLine);
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void Write (string message)
			{
			s_logger.WriteCore (message ?? string.Empty);
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void WriteLine (object value)
			{
			WriteLine ((value == null) ? string.Empty : value.ToString ());
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void WriteLine (object value, string category)
			{
			WriteLine ((value == null) ? string.Empty : value.ToString (), category);
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void WriteLine (string format, params object[] args)
			{
			WriteLine (string.Format (null, format, args));
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void WriteLine (string message, string category)
			{
			if (category == null)
				{
				WriteLine (message);
				}
			else
				{
				WriteLine (category + ":" + ((message == null) ? string.Empty : message));
				}
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void Write (object value)
			{
			Write ((value == null) ? string.Empty : value.ToString ());
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void Write (string message, string category)
			{
			if (category == null)
				{
				Write (message);
				}
			else
				{
				Write (category + ":" + ((message == null) ? string.Empty : message));
				}
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void Write (object value, string category)
			{
			Write ((value == null) ? string.Empty : value.ToString (), category);
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void Write (string format, params object[] args)
			{
			WriteLine (string.Format (null, format, args));
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void WriteIf (bool condition, string message)
			{
			if (condition)
				{
				Write (message);
				}
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void WriteIf (bool condition, object value)
			{
			if (condition)
				{
				Write (value);
				}
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void WriteIf (bool condition, string message, string category)
			{
			if (condition)
				{
				Write (message, category);
				}
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void WriteIf (bool condition, object value, string category)
			{
			if (condition)
				{
				Write (value, category);
				}
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void WriteIf (bool condition, string format, params object[] args)
			{
			if (condition)
				WriteLine (string.Format (null, format, args));
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void WriteLineIf (bool condition, object value)
			{
			if (condition)
				{
				WriteLine (value);
				}
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void WriteLineIf (bool condition, object value, string category)
			{
			if (condition)
				{
				WriteLine (value, category);
				}
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void WriteLineIf (bool condition, string value)
			{
			if (condition)
				{
				WriteLine (value);
				}
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void WriteLineIf (bool condition, string value, string category)
			{
			if (condition)
				{
				WriteLine (value, category);
				}
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void WriteLineIf (bool condition, string format, params object[] args)
			{
			if (condition)
				WriteLine (string.Format (null, format, args));
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void Print (string message)
			{
			WriteLine (message);
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void Print (string format, params object[] args)
			{
			WriteLine (format, args);
			}

#if SSHARP
		[System.Diagnostics.Conditional ("TRACE")]
		public static void Log (string message)
			{
			ErrorLog.Info (message);
			}

		[System.Diagnostics.Conditional ("TRACE")]
		public static void Log (string format, params object[] args)
			{
			ErrorLog.Info (format, args);
			}
#endif
		}
	}
