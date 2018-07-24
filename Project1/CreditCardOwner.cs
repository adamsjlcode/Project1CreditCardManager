//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 1 - Strings and Dates
//	File Name:		CardInfo.txt
//	Description:	Debugger text file for validation	
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Justin Adams, adamsjl3@etsu.edu, Undergrad CS, East Tennessee State University
//	Created:		Thursday, September 23, 2017
//	Copyright:		Justin Adams, 2017
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project1
{

	/// <summary>
	/// Holds and verify of credit card owner information and card information
	/// </summary>
	/// <seealso cref="System.IComparable{Project1.CreditCardOwner}" />
	/// <seealso cref="System.IEquatable{Project1.CreditCardOwner}" />
	public class CreditCardOwner : IComparable<CreditCardOwner>, IEquatable<CreditCardOwner>
	{
		/// <summary>
		/// The name
		/// </summary>
		private string _Name;

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		/// <exception cref="Exception">Invalid format needs to be at least two words: \n" +
		/// "John Doe\n" +
		/// "Business Inc." +
		/// "Please try again\n</exception>
		public string Name
		{

			get
			{
				return _Name;
			}//End get
			set
			{
				if (Regex.IsMatch (value, @"[^\s]+(\s.+)\b"))
				{
					_Name = value;
				} //End if statement
				else
				{
					_Name = "John Doe";
					throw new Exception ("Invalid format needs to be at least two words: \n" +
										"John Doe\n" +
										"Business Inc.");
				}//End else statement
			}//End set
		}//End Name

		/// <summary>
		/// The address
		/// </summary>
		private string _Address;

		/// <summary>
		/// Gets or sets the address.
		/// </summary>
		/// <value>
		/// The address.
		/// </value>
		/// <exception cref="Exception">Invalid format needs to be:\n" +
		/// 							"123 N. Example Street Example, TN 00000\n"</exception>
		public string Address
		{
			
			get
			{
				return _Address;
			}//End get
			set
			{
				if (Regex.IsMatch (value, @"\b\d+\s(?:[A-Za-z0-9.-]+[ ]?)+(?:\w+|\d+)\.?\s[a-zA-Z\s]+,\s(?:[A-Za-z0-9.-]+[ ]?[A-Za-z0-9.-]+)\s[a-zA-Z\s]{2}\s(\d{4,5})"))
				{
					_Address = value;
				} //End if statement
				else
				{
					_Address = "123 N. Example Street, Example TN 00000";
					throw new Exception ("Invalid format needs to be:\n" +
										"123 N. Example Street, Example TN 00000\n");	
				}//End else statement
			}//End set
		}//End Address

		/// <summary>
		/// The phone number
		/// </summary>
		private string _PhoneNumber;

		/// <summary>
		/// Gets or sets the phone number.
		/// </summary>
		/// <value>
		/// The phone number.
		/// </value>
		/// <exception cref="Exception">Invalid format needs to be:\n" +
		/// 							"000-000-0000\n</exception>
		public string PhoneNumber
		{
			get
			{
				return _PhoneNumber;
			}//End get
			set
			{
				if (Regex.IsMatch (value, @"\b[0-9]{3}-[0-9]{3}-[0-9]{4}"))
				{
					_PhoneNumber = value;
				}//End if statement
				else
				{
					_PhoneNumber = "000-000-0000";
					throw new Exception ("Invalid format needs to be:\n" +
										"000-000-0000\n");
					_PhoneNumber = "000-000-0000";
				}//End else statement
			}//End set
		}//End PhoneNumber

		/// <summary>
		/// The email address
		/// </summary>
		private string _EmailAddress;

		/// <summary>
		/// Gets or sets the email address.
		/// </summary>
		/// <value>
		/// The email address.
		/// </value>
		/// <exception cref="Exception">Invalid format needs to be:\n" +
		/// "example@example.com\n"</exception>
		public string EmailAddress
		{
			get
			{
				return _EmailAddress;
			}//End get
			set
			{
				if (Regex.IsMatch (value, @"\b[a-z0-9._%=+-]+@[a-z0-9._%=-\[]+.\w{2,}"))
				{
					_EmailAddress = value;
				}//End if statement
				else
				{
					_EmailAddress = "example@example.com";
					throw new Exception ("Invalid format needs to be:\n" +
										"example@example.com\n");
				}//End else statement
			}//End set
		}//End EmailAddress

		/// <summary>
		/// The credit cards in list
		/// </summary>
		private List<CreditCard> Cards;
		/// <summary>
		/// If user has cards stored in list
		/// </summary>
		public bool HasCards = false;
		/// <summary>
		/// Gets the cards.
		/// </summary>
		/// <param name="number">The number.</param>
		/// <returns></returns>
		public string GetCards (int number)
		{
			return Cards [number + 1].ToString ( );
		}//End GetCards (int)

		/// <summary>
		/// Sets the cards.
		/// </summary>
		/// <param name="card">The card.</param>
		public void SetCards (CreditCard card)
		{
			if (Cards == null)
			{
				Cards = new List<CreditCard> ( );
				Cards.Add (new CreditCard (card));
				HasCards = true;
			}//End if statement
			else
			{
				Cards.Add (new CreditCard (card));
				HasCards = true;
			}//End else statement
		}//End SetCards	(CreditCard)

		/// <summary>
		/// Initializes an default instance of the <see cref="CreditCardOwner"/> class.
		/// </summary>
		public CreditCardOwner ( )
		{
			Name = "John Doe";
			Address = "123 N. Example Street, Example TN 00000";
			PhoneNumber = "000-000-0000";
			EmailAddress = "example@example.com";
			Cards = new List<CreditCard> ( );
		}//End CreditCardOwner ( )

		/// <summary>
		/// Initializes a new instance of the <see cref="CreditCardOwner"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="address">The address.</param>
		/// <param name="phoneNumber">The phone number.</param>
		/// <param name="emailAddress">The email address.</param>
		public CreditCardOwner (string name, string address, string phoneNumber, string emailAddress)
		{
			this.Name = name;
			this.Address = address;
			this.PhoneNumber = phoneNumber;
			this.EmailAddress = emailAddress;
		}//End CreditCardOwner (string, string, string, string, string)

		/// <summary>
		/// Initializes a new instance of the <see cref="CreditCardOwner"/> class.
		/// </summary>
		/// <param name="creditCardOwner">The credit card owner.</param>
		public CreditCardOwner (CreditCardOwner creditCardOwner)
		{
			this.Name = creditCardOwner.Name;
			this.Address = creditCardOwner.Address;
			this.PhoneNumber = creditCardOwner.PhoneNumber;
			this.EmailAddress = creditCardOwner.EmailAddress;
			this.Cards = new List<CreditCard> (creditCardOwner.Cards);
		}//End CreditCardOwner (CreditCardOwner)

		#region IComparable<CreditCardOwner> implementation
		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="other">An object to compare with this instance.</param>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="other" /> in the sort order.  Zero This instance occurs in the same position in the sort order as <paramref name="other" />. Greater than zero This instance follows <paramref name="other" /> in the sort order.
		/// </returns>
		public int CompareTo (CreditCardOwner other)
		{
			return base.GetHashCode ( ).CompareTo (other.GetHashCode ( ));
		}//End CompareTo (CreditCardOwner)
		#endregion

		#region IEquatable<Name> implementation
		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
		/// </returns>
		bool IEquatable<CreditCardOwner>.Equals (CreditCardOwner other)
		{
			return Name == other.Name;
		}//End IEquatable<CreditCardOwner>.Equals (CreditCardOwner)

		/// <summary>
		/// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
		/// <returns>
		///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		/// <exception cref="ArgumentException">Parameter is not a credit card owner</exception>
		public override bool Equals (object obj)
		{
			if (obj == null)
			{
				return base.Equals (obj);
			}
			else if (!(obj is CreditCardOwner))
			{
				throw new ArgumentException ("Parameter is not a credit card owner");
			}
			else return base.Equals (obj as CreditCardOwner);
		}//End Equals (object)

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		public override int GetHashCode ( )
		{
			return Name.GetHashCode ( );
		}//End GetHashCode ( )
		#endregion

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString ( )
		{
			string strTemp = "Name: \t\t" + this.Name +
							"\nAddress: \t" + this.Address +
							"\nPhone: \t\t" + this.PhoneNumber +
							"\nEmail: \t\t" + this.EmailAddress;
			if (Cards != null)
			{
				foreach (CreditCard card in Cards)
				{
					strTemp += card.ToString ( );
				}//End for-each
			}//End if statement
			return strTemp;
		}//End ToString ( ) 
	}//End CreditCardOwner
}//End Project1
