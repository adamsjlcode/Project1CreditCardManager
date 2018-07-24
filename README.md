# Project 1 Credit Card Manager
## Purpose

![](media/ebed013e538686e62ce1a9283370afa8.png)

The purpose of this assignment is to gain some experience using the Visual
Studio IDE to create, edit, and debug a C\# console application with multiple
classes that include Strings and Regular Expressions (only for user
information). The context of the assignment is the management and verification
of credit card information. In doing so, you will use enumerated data types,
Strings, date information, and other capabilities of C\#.

## Overview

Using Visual Studio, create a solution and project with at least three C\#
classes (you may create more than three) including a driver class to handle all
I/O, a **CreditCard** class that encapsulates and manages the information for a
credit card, and a **CreditCardOwner** class that manages the holder’s name,
address, and phone number. The solution will input data from the user, create a
credit card object that manages and verifies that data, and produces a brief
report. The program should continue as long as the user has additional credit
card information to process.

## Specifications

-   All I/O should be done in the driver.

-   The driver should be menu driven and give the user an opportunity to enter
    credit card information from which a report on that card will be generated
    until the user has no more information to process.

-   All information in the regarding a CreditCard should be managed with .NET’s
    String class. Information concerning the credit card holder’s name, phone
    number, and email address may be validated with Regular Expressions where
    appropriate.

-   The information for each credit card will include the card holder’s name
    (*String*), the credit card number (*String*), and the expiration date in
    the form MM/YYYY (*String*). In addition, the program should input the card
    holder’s telephone number (*String*) and email address (*String*). The
    credit card number should be entered as a string of digits without spaces or
    other separator characters (for example, the user will type 1234567890120987
    rather than 1234 5678 9012 0987). The program should remove any extraneous
    characters that might have been entered.

-   The *CreditCard* class will maintain the information input above in separate
    fields. It may have additional fields for things such as whether the credit
    card number is valid. It should also have a field for the credit card type
    (types used for our purposes are *INVALID*, *VISA*, *MASTERCARD*,
    *AMERICAN*\_*EXPRESS*, *DISCOVER*, and *OTHER*). The expiration date field
    can be two separate fields for month and year if you wish.

-   The type of card should be managed as an *enumerated data type*, and it can
    be determined from the credit card number. See the attachment at the end of
    this assignment for details.

-   A credit card has expired if the expiration date is this month or before –
    e.g., a card that expires 2/2016 expires on 2/1/2016. You will have to get
    the current date from the computer and compare the current month and current
    year to the month and year of expiration to determine whether or not the
    card has expired.

-   The attachment at the end of this assignment also describes how to check
    whether a credit card number is a valid number. Note that a number may be
    valid without belonging to the customer whose name is on the card, but your
    task does not involve matching the name and the number – only verifying that
    the number is a valid number. To show the number is valid, use *Luhn’s
    algorithm* as shown in the attachment. You must use Luhn’s algorithm as
    descrived.

-   Validate the telephone number and the email address using regular
    expressions.

## Hints and Suggestions

-   Data in this assignment is *String* information. You will need to use some
    of the methods in the *String* class and methods in the *Decimal* structure
    to manipulate this data for this assignment. Complete documentation for
    these can be found at Visual Studio help system.

-   You can access one character at a time in the credit card number, convert it
    to a *Decimal* number using the *Parse* method from the *Decimal*
    (class-like) structure, and then do the manipulation required in the
    attached instructions to validate the number. Do not allow the validation to
    become more complicated than necessary – more than about 15 lines of code is
    excessive.

-   To get the current date from the computer to determine whether the
    expiration date has passed, use the following code.

>   DateTime CurrentDate **=** DateTime**.**Today;

-   Individual components of the date such as the *month number* and the *year*
    can be retrieved using code such as the following.

>   **int** CurrentMonth **=** CurrentDate**.**Month; *// CurrentMonth is now in
>   range 1 - 12*

>   **int** CurrentYear **=** CurrentDate**.**Year; *// CurrentYear is a 4-digit
>   number such as 2016*


## Background 

**Card Number Length** 

Typically, credit card numbers are numeric and the length of the card number is
between 12 digits and 19 digits. The spaces on a credit card between groups of
numbers are only for human readers and are not part of the card number.

-   14, 15, 16 digits – **Diners Club**

-   15 digits – **American Express**

-   13, 16 digits – **Visa**

-   16 digits - **MasterCard**  

For more information please
refer <http://en.wikipedia.org/wiki/Bank_card_number>.

**Embedded information**

![http://www.codeproject.com/KB/recipes/515367/image_thumb7.png](media/a02e4fd05c71f7fc497e46d3b36720bd.png)

1.  * Major Industry Identifier (MII)* 

>   The first digit of the credit card number is the **Major Industry Identifier
>   (MII)**. It designates the category of the entity which issued the card.    

-   1 and 2 – Airlines 

-   3 – Travel

-   4 and 5 – Banking and Financial

-   6 – Merchandising and Banking/Financial

-   7 – Petroleum

-   8 – Healthcare, Telecommunications

-   9 – National Assignment 

1.  *Issuer Identification Number *

>   The first 6 digits are the **Issuer Identification Number (IIN)**. It will
>   identify the institution that issued the card. Following are some (but by no
>   means all) of the familiar **IIN**’s. 

-   **American Express** – 34xxxx, 37xxxx 

-   **Visa** – 4xxxxxx 

-   **MasterCard** – 51xxxx – 55xxxx 

-   **Discover** – 6011xx, 644xxx, 65xxxx 

>   The remaining digits among these first 6 may identify a bank or other entity
>   that issued the card. For example, if the first six digits are 416724, the
>   card is a **Wells Fargo Bank Debit Visa (USA)** card. Try
>   <https://www.bindb.com/bin-database.html> to use the IIN of a credit card to
>   show its type and issuer information.

1.  *Account Number *

>   Taking away the 6 identifier digits and the last digit, the remaining digits
>   are the person’s unique account number (the 7th and following digits up to
>   but excluding the last digit) 

1.  *Check Digit  * 

>   The last digit is known as a check digit or checksum. It is used to validate
>   the credit card number using the **Luhn algorithm (Mod 10 algorithm)** that
>   is described below. 

>   For more information about these and related topics refer to:
>   <http://en.wikipedia.org/wiki/Bank_card_number>.

## Luhn algorithm (Mod 10)  

The **Luhn algorithm**, also known as the “**modulus 10**″ or “**mod 10**″
algorithm, is a simple checksum algorithm used to validate a variety of
identification numbers, such as credit card numbers, IMEI numbers, National
Provider Identifier numbers in the US and Canadian Social Insurance Numbers. It
was created by IBM scientist Hans Peter Luhn
(<http://en.wikipedia.org/wiki/Luhn_algorithm>).

When you implement ecommerce applications, it is a best practice to validate the
credit card number before sending it to the bank for validation. Note that just
because a credit card number is verified by Luhn’s algorithm, that does not mean
the number has been assigned to the person whose name is on the card. It only
means that the number meets all requirements for being a valid number. A number
that fails Luhn’s algorithm cannot be a valid credit card number.

Here are the Luhn steps which can be used to validate the credit card number. 

**4 0 1 2 8 8 8 8 8 8 8 8 1 8 8 1**  

**Step 1** - Starting with the check digit double the value of every other digit
(right to left every 2nd digit)  

![](media/d975f487ff2675cd7946e6c926743c1f.png)

>   http://www.codeproject.com/KB/recipes/515367/1.png

**Step 2** - If doubling a number results in a two digit number, add the digits
to get a single digit number. This will result in eight single digit numbers.

![](media/a3636d883b5889ac24b6712385403c65.png)

>   Step 2

>    

**Step 3** - Now add the un-doubled digits to the odd places

![](media/abb6594635a5f8a98be0ab42863e9341.png)

>   http://www.codeproject.com/KB/recipes/515367/3.png

>    

**Step 4** - Add up all the digits in this number

![](media/ed9ec18a97390ab6d66c44f028949ee9.png)

>   http://www.codeproject.com/KB/recipes/515367/4.png

If the final sum is divisible by 10, then the credit card number is **valid**.
If it is not divisible by 10, the number is **invalid**. 

## Some Test Data

Some data you may use to test is in the following table. These numbers should be
determined to be valid card numbers by your code. Use other (valid and invalid)
data in your testing as well, possibly including your own credit card number(s).

| MasterCard | 5499990123456781 |
|------------|------------------|
| Visa       | 4003000123456781 |
| AMEX       | 373953244361001  |
| Discover   | 6011000997235373 |

Bottom of Form
