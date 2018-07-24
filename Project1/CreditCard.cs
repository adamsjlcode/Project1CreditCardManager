//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 1 - Strings and Dates
//	File Name:		CreditCard.cs
//	Description:	Credit Card Class used to validate information provided by user	
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Justin Adams, adamsjl3@etsu.edu, Undergrad CS, East Tennessee State University
//	Created:		Thursday, September 19, 2017
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
	///	The Card Type
	/// </summary>
	public enum CardType
	{
		/// <summary>
		/// The invalid
		/// </summary>
		INVALID,
		/// <summary>
		/// The visa
		/// </summary>
		VISA,
		/// <summary>
		/// The Mastercard
		/// </summary>
		MASTERCARD,
		/// <summary>
		/// The American express
		/// </summary>
		AMERICAN_EXPRESS,
		/// <summary>
		/// The discover
		/// </summary>
		DISCOVER,
		/// <summary>
		/// The diners club
		/// </summary>
		DINERS_CLUB,
		/// <summary>
		/// The other
		/// </summary>
		OTHER
	}
	/// <summary>
	///	Major Industry Identifier  
	/// </summary>
	public enum MII
	{
		/// <summary>
		/// The invalid
		/// </summary>
		INVALID,
		/// <summary>
		/// The airlines
		/// </summary>
		AIRLINES,
		/// <summary>
		/// The travel
		/// </summary>
		TRAVEL,
		/// <summary>
		/// The banking and financial
		/// </summary>
		BANKING_AND_FINANCIAL,
		/// <summary>
		/// The merchandising and banking financial
		/// </summary>
		MERCHANDISING_AND_BANKING_FINANCIAL,
		/// <summary>
		/// The petroleum
		/// </summary>
		PETROLEUM,
		/// <summary>
		/// The health care telecommunications
		/// </summary>
		HEALTHCARE_TELECOMMUNICATIONS,
		/// <summary>
		/// The national assignment
		/// </summary>
		NATIONAL_ASSIGNMENT
	}
	/// <summary>
	/// Credit card class used to store and valid credit card information  
	/// </summary>
	public class CreditCard
	{
		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>
		/// The type.
		/// </value>
		private CardType Type { get; set; }//End CardType
		
		/// <summary>
		/// Gets or sets the mii.
		/// </summary>
		/// <value>
		/// The mii.
		/// </value>
		private MII MII { get; set; }//End MII
		
		/// <summary>
		/// Gets or sets the iin.
		/// </summary>
		/// <value>
		/// The iin.
		/// </value>
		private string IIN { get; set; }//End IIN
		
		/// <summary>
		/// Gets or sets the account number.
		/// </summary>
		/// <value>
		/// The account number.
		/// </value>
		private string AccountNumber { get; set; }//End	AccountNumber
		
		/// <summary>
		/// Gets or sets the check digit.
		/// </summary>
		/// <value>
		/// The check digit.
		/// </value>
		private string CheckDigit { get; set; }//End CheckDigit
		
		/// <summary>
		/// Gets or sets the expiration.
		/// </summary>
		/// <value>
		/// The expiration.
		/// </value>
		private string Expiration { get; set; }//End Expiration
		
		/// <summary>
		/// The current date
		/// </summary>
		public DateTime CurrentDate = DateTime.Today;

		/// <summary>
		/// Initializes a new instance of the <see cref="CreditCard"/> class.
		/// </summary>
		public CreditCard ( )
		{

		}//End CreditCard

		/// <summary>
		/// Initializes a new instance of the <see cref="CreditCard"/> class.
		/// </summary>
		/// <param name="iIN">The i in.</param>
		/// <exception cref="Exception">Invalid Card Number</exception>
		public CreditCard (string iIN ,string expiration)
		{
			//Removes any unusable characters from card number
			for (int i = 0 ; i < iIN.Length ; i++)
			{
				if (iIN [i].ToString ( ).Contains(@" \][|}{+=_-)(*&^%$#@!`~:;<,>.?/"))
				{
					iIN.Remove (i, 1);
					i--; 
				}
			}
			if (LuhnAlgorithm(iIN))
			{
				//Set the IIN number
				IIN = iIN;
				//Find Major Industry Identifier Type
				MajorIndustryIdentifierType (iIN [0].ToString ( ));
				//Find Check Card Type
				CheckCardType (iIN);
				//Remove Major Industry Identifier
				iIN = iIN.Remove (0 , 1);
				//Find Check Digit
				CheckDigit = iIN [iIN.Length - 1].ToString ( );
				//Remove Check Digit
				iIN = iIN.Remove (iIN.Length - 1, 1);
				//Find Account Number
				AccountNumber = iIN.Substring (iIN.Length -6);
				//End Check Expiration
				CheckExpiration (expiration);
			}//End if statement
			else
			{
				//Throw error message if card number is invalid
				throw new Exception ("Invalid Card Number");
			}//End else statement
		}//End CreditCard (string)

		/// <summary>
		/// Initializes a copy instance of the <see cref="CreditCard"/> class.
		/// </summary>
		/// <param name="card">The card.</param>

		public CreditCard (CreditCard card)
		{
			this.Type = card.Type;
			this.MII = card.MII;
			this.IIN = card.IIN;
			this.AccountNumber = card.AccountNumber;
			this.CheckDigit = card.CheckDigit;
			this.Expiration = card.Expiration;
		}//End CreditCard (CreditCard)

		/// <summary>
		/// Luhns the algorithm.
		/// </summary>
		/// <param name="IIN">The iin.</param>
		/// <returns>If card number is a valid number</returns>
		public bool LuhnAlgorithm (string IIN)
		{
			int Sum = 0;		//Holder of the sum of card number
			string StrTemp =""; //Holder of string value for validating
			
			//Run backwards through card to check if card number is valid
			for (int i = IIN.Length - 1 ; i >= 0 ; i--)
			{
				//Store number character in temporary holder  
				StrTemp = IIN [i].ToString ( );
				//Check if current index is even
				if (i%2 == 0)
				{
					//Check if current digit multiply by two is over ten
					if (Int32.Parse(StrTemp) * 2 >= 10)
					{
						//Multiply by two
						StrTemp = (Int32.Parse (StrTemp) * 2).ToString ( );
						//Add two digits together to sum
						Sum += Int32.Parse (StrTemp [0].ToString ( )) +
							Int32.Parse (StrTemp [1].ToString ( ));
					}//End if statement
					 //Multiply by two and add to sum
					else
					{

						StrTemp = (Int32.Parse (StrTemp) * 2).ToString ( );
						Sum += Int32.Parse (StrTemp);
					}//End else statement
				}//End if statement
				//The index is odd
				else
				{
					//Add current digit to sum
					Sum += Int32.Parse (StrTemp);
				}//End else statement
			}//end for loop
			return (Sum % 10 == 0);
		}//End LuhnAlgorithm (string)
		 
		/// <summary>
		/// Checks the type of the card.
		/// </summary>
		/// <param name="iIN">The i in.</param>
		public void CheckCardType (string iIN)
		{
			if (Regex.Match(iIN, @"\b4\d{12}|(\b4\d{15})").Success)
			{
				Type = CardType.VISA;
			}//End if statement
			else if (Regex.Match (iIN, @"\b5(1|5)\d{14}").Success)
			{
				Type = CardType.MASTERCARD;
			}//End else if statement
			else if (Regex.Match (iIN, @"\b3(4|7)\d{13}").Success)
			{
				Type = CardType.AMERICAN_EXPRESS;
			}//End else if statement
			else if (Regex.Match (iIN, @"(\b6011\d{11})|(\b644\d{12})|(\b65\d{13})").Success)
			{
				Type = CardType.DISCOVER;
			}//End else if statement
			else if (Regex.Match (iIN, @"\b30(0,5)\d{11}").Success)
			{
				Type = CardType.DINERS_CLUB;
			}//End else if statement
			else
			{
				Type = CardType.INVALID;
			}//End else statement
		}//End CheckCardType (string)

		/// <summary>
		/// Majors the type of the industry identifier.
		/// </summary>
		/// <param name="iIN">The i in.</param>
		public void MajorIndustryIdentifierType (string iIN)
		{
			switch (Int32.Parse (iIN [0].ToString ( )))
			{
				case 1:
				case 2:
					MII = MII.AIRLINES;
					break;
				case 3:
					MII = MII.TRAVEL;
					break;
				case 4:
				case 5:
					MII = MII.BANKING_AND_FINANCIAL;
					break;
				case 6:
					MII = MII.MERCHANDISING_AND_BANKING_FINANCIAL;
					break;
				case 7:
					MII = MII.PETROLEUM;
					break;
				case 8:
					MII = MII.HEALTHCARE_TELECOMMUNICATIONS;
					break;
				case 9:
					MII = MII.NATIONAL_ASSIGNMENT;
					break;
				default:
					break;
			}//End switch statement
		}//End MajorIndustryIdentifierType (string)

		/// <summary>
		/// Checks the expiration.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <exception cref="Exception">Invalid Expiration Date</exception>
		public void CheckExpiration (string date)
		{
			if (Regex.IsMatch(date, @"\b((1(1|2))|(0[1-9]))/[1-9]\d"))
			{
				string [ ] temp = date.Split('/');
				//Check year
				if (CurrentDate.Year == Int32.Parse (temp [1]))
				{
					//Check month
					if (CurrentDate.Month < Int32.Parse (temp [0]))
					{
						throw new Exception ("Invalid Expiration Date");
					}//End if statement
				}//End if statement
				else
				{
					Expiration = date;
				}//End else statement	
			}//End if statement
			else
			{
				throw new Exception ("Invalid Expiration Date");
			}//End else statement
		}//End CheckExpiration (string)
		
		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString ( )
		{

			return "\nMII:\t\t\t\t" + MII + 
					"\nIIN:\t\t\t\t" + IIN  + 
					"\nAccount Number:\t\t" + AccountNumber +
					"\nCheck Digit:\t\t\t " + CheckDigit +
					"\nExpiration:\t\t" + Expiration  +
					"\nType:\t\t\t\t" + Type +
					"\nLuhn:\t\t\t\t" + LuhnAlgorithm(IIN);
		}//End ToString ( )
	}//End CreditCard
}//End Project1
