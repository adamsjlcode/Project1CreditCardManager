//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 1 - Strings and Dates
//	File Name:		CreditCardDriver.cs
//	Description:	CreditCardDriver for Credit Card Class for user	
//	Course:			CSCI 2210-001 - Data Structures
//	Author:			Justin Adams, adamsjl3@etsu.edu, Undergrad CS, East Tennessee State University
//	Created:		Thursday, September 19, 2017
//	Copyright:		Justin Adams, 2017
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
	/// <summary>
	/// Credit Card Driver Program
	/// </summary>
	class CreditCardDriver
	{
		/// <summary>
		/// Mains the specified arguments.
		/// </summary>
		/// <param name="args">The arguments.</param>
		static void Main (string [ ] args)
		{
			ConsoleColor Background = ConsoleColor.Blue;
			ConsoleColor Foreground = ConsoleColor.White;
			//Console.CursorVisible = false;
			string [ ] MenuMain = { "Create User", "Display User", "Update User", "Add Credit Card To User","Exit" };
			string [ ] MenuChange = { "Name","Address","Phone","Email","Credit Card" };
			string welcomeMessage = "Welcome to the customer control log. This program will allow you to add new customers" +
				", update existing customers, and store their forms of payment. Where would you like to start?";
			string exitMessage = "Thank you, for using this program if you have any question.\n" +
									"\nPlease contact me at:\n\n" +
									"Justin Adams\n" +
									"Adamsjl3@etsu.edu\n" +
									"CSCI 2210\n";
			List<CreditCardOwner> Users = new List<CreditCardOwner> ( );
			CreditCardOwner ownerTemp = null;
			try
			{
				ownerTemp = new CreditCardOwner ( );
			}//End try statement
			catch (Exception e)
			{
				//Display Error Message
				MessageBox.Show (e.Message,
								"Error",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
			}//End catch statement
			 
			CreditCard cardTemp = new CreditCard ( );
			bool GoOn = false;
			
			//Set Colors for Console
			Console.BackgroundColor = Background;
			Console.ForegroundColor = Foreground;
			Console.Clear ( );

			//Display Welcome Message
			Utility.Message (welcomeMessage,"Welcome");
			int Selection = -1;
			do
			{
				Selection = -1;
				try
				{
					Selection = Utility.Menu (MenuMain);
				}//End try statement
				catch (Exception e)
				{
					//Display Error Message
					MessageBox.Show (e.Message,
									"Error",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error);
				}//End catch statement
				switch (Selection)
				{
					case 1://Get info from user
						ownerTemp = new CreditCardOwner ( );
						try
						{
							ownerTemp.Name = Utility.GetData (MenuChange [0]);
						}//End try statement
						catch (Exception e)
						{
							//Display Error Message
							MessageBox.Show (e.Message,
											"Error",
											MessageBoxButtons.OK,
											MessageBoxIcon.Error);
						}//End catch statement
						try
						{
							ownerTemp.Address = Utility.GetData (MenuChange [1]);
						}//End try statement
						catch (Exception e)
						{
							//Display Error Message
							MessageBox.Show (e.Message,
											"Error",
											MessageBoxButtons.OK,
											MessageBoxIcon.Error);
						}//End catch statement
						try
						{
							ownerTemp.PhoneNumber = Utility.GetData (MenuChange [2]);
						}//End try statement
						catch (Exception e)
						{
							//Display Error Message
							MessageBox.Show (e.Message,
											"Error",
											MessageBoxButtons.OK,
											MessageBoxIcon.Error);
						}//End catch statement
						try
						{
							ownerTemp.EmailAddress = Utility.GetData (MenuChange [3]);
						}//End try statement
						catch (Exception e)
						{
							//Display Error Message
							MessageBox.Show (e.Message,
											"Error",
											MessageBoxButtons.OK,
											MessageBoxIcon.Error);
						}//End catch statement
						Users.Add (ownerTemp);
						break;
					case 2://Display User 
						int IndexOfUser = -1;
						if (Users.Count != 0)
						{
							do
							{
								try
								{
									Console.Clear ( );
									IndexOfUser = DisplayUser (Users);
									Console.Clear ( );
									Console.WriteLine (Users [IndexOfUser].ToString ( ));
									Utility.PressAnyKey ( );
									GoOn = true;
								}//End try statement
								catch (Exception e)
								{
									IndexOfUser = -1;
									//Display Error Message
									MessageBox.Show (e.Message,
													"Error",
													MessageBoxButtons.OK,
													MessageBoxIcon.Error);
								}//End catch statement
							} while (!GoOn);//End do-while statement
						}
						else
						{
							//Display Error Message
							MessageBox.Show ("There are no users in the file.\nPlease add a user first.",
											"Error",
											MessageBoxButtons.OK,
											MessageBoxIcon.Error);
						}//End else statement
						break;
					case 3://Edit Information
						IndexOfUser = -1;
						GoOn = false;
						if (Users.Count != 0)
						{
							do
							{
								try
								{
									Console.Clear ( );
									IndexOfUser = DisplayUser (Users);
									Console.Clear ( );
									GoOn = true;
								}//End try statement
								catch (Exception e)
								{
									IndexOfUser = -1;
									//Display Error Message
									MessageBox.Show (e.Message,
													"Error",
													MessageBoxButtons.OK,
													MessageBoxIcon.Error);
								}//End catch statement
							} while (!GoOn);//End do-while statement
							int ChooseTemp = Utility.Menu (MenuChange);	//Index of user choice
							switch (ChooseTemp)
							{
								case 1://Change name
									try
									{
										Users [IndexOfUser].Name = Utility.GetData (MenuChange [0]);
									}//End try statement
									catch (Exception e)
									{
										//Display Error Message
										MessageBox.Show (e.Message,
														"Error",
														MessageBoxButtons.OK,
														MessageBoxIcon.Error);
									}//End catch statement
									break;
								case 2://Change address
									try
									{
										Users [IndexOfUser].Address = Utility.GetData (MenuChange [1]);
									}//End try statement
									catch (Exception e)
									{
										//Display Error Message
										MessageBox.Show (e.Message,
														"Error",
														MessageBoxButtons.OK,
														MessageBoxIcon.Error);
									}//End catch statement
									break;
								case 3://Change phoneNumber
									try
									{
										Users [IndexOfUser].PhoneNumber = Utility.GetData (MenuChange [2]);
									}//End try statement
									catch (Exception e)
									{
										//Display Error Message
										MessageBox.Show (e.Message,
														"Error",
														MessageBoxButtons.OK,
														MessageBoxIcon.Error);
									}//End catch statement
									break;
								case 4://Change Email Address
									try
									{
										Users [IndexOfUser].EmailAddress = Utility.GetData (MenuChange [3]);
									}//End try statement
									catch (Exception e)
									{
										//Display Error Message
										MessageBox.Show (e.Message,
														"Error",
														MessageBoxButtons.OK,
														MessageBoxIcon.Error);
									}//End catch statement
									break;
								case 5://Change Credit Card
									if (Users [IndexOfUser].HasCards)
									{
										Console.Clear ( );
										Users [DisplayUser (Users)].SetCards (CreateCard ( ));
										Console.Clear ( );
									}//End if statement
									else
									{
										//Display Error Message
										MessageBox.Show ("There are no cards to update try adding one first",
														"Error",
														MessageBoxButtons.OK,
														MessageBoxIcon.Error);
									}//End else statement
									break;
								default:
									break;
							}
						}
						else
						{
							//Display Error Message
							MessageBox.Show ("There are no users in the file.\nPlease add a user first.",
											"Error",
											MessageBoxButtons.OK,
											MessageBoxIcon.Error);
						}//End else statement
						break;
					case 4:
						if (Users.Count != 0)
						{
							try
							{
								Console.Clear ( );
								Users [DisplayUser (Users)].SetCards (CreateCard ( ));
								Console.Clear ( );
							}//End try statement
							catch (Exception e)
							{
								//Display Error Message
								MessageBox.Show (e.Message,
												"Error",
												MessageBoxButtons.OK,
												MessageBoxIcon.Error);
							}//End catch statement 
						}//End if statement
						else
						{
							//Display Error Message
							MessageBox.Show ("There are no users in the file.\nPlease add a user first.",
											"Error",
											MessageBoxButtons.OK,
											MessageBoxIcon.Error);
						}//End else statement
						break;
					case 5://Exit Program
						//Display Developer Info
						Utility.Message (exitMessage,"Exit");
						//Exit Program
						Environment.Exit (0);
						break;
					default:
						break;
				}
			} while (Selection != 5);
		}//End Main (string [ ])

		 /// <summary>
		 /// Displays the user.
		 /// </summary>
		 /// <param name="users">The users.</param>
		 /// <returns>Index of selected user to modify or view</returns>
		public static int DisplayUser (List<CreditCardOwner> users)
		{
			int IndexOfUser;	//Index of users
			do
			{
				Console.Clear ( );
				Console.WriteLine ("Please Make A Selection");
				//Display all users 
				for (int i = 0 ; i < users.Count ; i++)
				{
					Console.WriteLine ((i + 1) + ". " + users [i].Name);
				}//end for loop
				try
				{
					IndexOfUser = Int32.Parse (Console.ReadLine ( ));
				}//End try statement
				catch (Exception e)
				{

					IndexOfUser = -1;
					//Display Error Message
					MessageBox.Show (e.Message,
									"Error",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error);
				}//End catch statement
			} while (IndexOfUser < 0 || IndexOfUser > users.Count);
			return IndexOfUser -1;
		}//End DisplayUser(List<CreditCardOwner>)

		 /// <summary>
		 /// Creates the card.
		 /// </summary>
		 /// <returns>A new credit card for user</returns>
		public static CreditCard CreateCard ( )
		{
			CreditCard TempCard = null;	//Creates a temporarily credit card holder
			string CardNumber = "";		//Holder of card number
			string Expiration = "";     //Holder of the card expiration
			Console.Clear ( );
			//Ask user for card number
			Console.WriteLine ("What is the card number");
			CardNumber = Console.ReadLine ( );
			//Ask user for expiration
			Console.WriteLine ("What is the expiration");
			Expiration = Console.ReadLine ( );
			try
			{
				//Create new credit card
				TempCard = new CreditCard (CardNumber, Expiration);
				Console.Clear ( );
				Console.WriteLine ("Valid Card\nThank you");
			}//End try statement
			catch (Exception e)
			{
				//Display Error Message
				MessageBox.Show (e.Message,
								"Error",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
			}//End catch statement
			return TempCard;
		}//End CreateCard ( ) 
	}//End CreditCardDriver
}//End Project1
	 