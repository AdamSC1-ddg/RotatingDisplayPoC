using System;

namespace test
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			//Set string to track last combination displayed. Start at C2 for fresh cycle
			string Last = "";

			//Create boolean int for all possible combinations we want to cycle through
			int A1 = 0;
			int B2 = 0;
			int C3 = 0;
			int A2 = 0;
			int B3 = 0;
			int C1 = 0;
			int A3 = 0;
			int B1 = 0;
			int C2 = 0;

			int hour = DateTime.Now.Hour; //Getting current server hour (24)
			int date = DateTime.Now.Day; //Getting current date

			//Check if day is 2, 14, 22 if so check for the most recent combination displayed and toggle on relevant combination variables
			if (date == 2)
			{
				if (Last == "C3")
				{
					A1 = 0;
					A2 = 1;
					A3 = 0;
				}
				else if (Last == "C1")
				{
					A1 = 0;
					A2 = 0;
					A3 = 1;
				}
				else if (Last == "C2")
				{

					A1 = 1;
					A2 = 0;
					A3 = 0;
				}
				else {
					//if date matches a letter var but the last displayed combination is not the one before that letter var then all vars should be off
					A1 = 0;
					A2 = 0;
					A3 = 0;
					B1 = 0;
					B2 = 0;
					B3 = 0;
					C1 = 0;
					C2 = 0;
					C3 = 0;
				}
			}

				else if (date == 14)
				{
					if (Last == "A1")
					{
						B1 = 0;
						B2 = 1;
						B3 = 0;
					}
					else if (Last == "A2")
					{
						B1 = 0;
						B2 = 0;
						B3 = 1;
					}
					else if (Last == "A3")
					{
						B1 = 1;
						B2 = 0;
						B3 = 0;
					}
					else {
						A1 = 0;
						A2 = 0;
						A3 = 0;
						B1 = 0;
						B2 = 0;
						B3 = 0;
						C1 = 0;
						C2 = 0;
						C3 = 0;
					}
				}
				else if (date == 22)
				{

					if (Last == "B3")
					{
						C1 = 0;
						C2 = 1;
						C3 = 0;
					}
					else if (Last == "B1")
					{
						C1 = 0;
						C2 = 0;
						C3 = 1;
					}
					else if (Last == "B2")
					{
						C1 = 1;
						C2 = 0;
						C3 = 0;
					}
					else {
						A1 = 0;
						A2 = 0;
						A3 = 0;
						B1 = 0;
						B2 = 0;
						B3 = 0;
						C1 = 0;
						C2 = 0;
						C3 = 0;
					}
				}

				else {
					A1 = 0;
					A2 = 0;
					A3 = 0;
					B1 = 0;
					B2 = 0;
					B3 = 0;
					C1 = 0;
					C2 = 0;
					C3 = 0;
				}

//Set int to track if the modal is currently displaying or not			
int showing = 0;

			//for each date check to see if that date is one of our parameter days. If so we proceed to check the hours
			if (date == 2)
			{
				//if it is between 6AM and Noon, and A1 should be toggled and was not the last ad toggled we should turn it on
				if ((hour >= 6 && hour <= 11) && (A1 == 1) && (Last != "A1")){
					//We trigger the fictional function modal_display to turn on the modal, modal_display() is assumed to have all current logic related to other params
					modal_display();
					//We set showing to 1 so we know the ad is on. We don't change the Last variable yet because this is an hourly cron
					showing = 1;
				}
				//Once outside of the expected show times we check to see if the ad is showing. If it is we trigger modal_stop, a fictional event to turn off the modal. We then set showing to off, record what the last combination to show was and then set A1 to off to say it should no longer trigger today.
				if ((hour == 12) && (showing == 1)){
					modal_stop();
					showing = 0;
					Last = "A1";
					A1 = 0;
				}
				//If it is between 1PM but is not yet 4PM and A2 should be on and was not the last display combination then shwo the modal.
				if (((hour >= 13 && hour < 16) && (A2 == 1)) && (Last != "A2")){
					modal_display();
					showing = 1;
				}
				//If it is 4PM, or after 4PM but before 11PM and a modal is showing then set it to off and record the last variable.
				if ((hour == 16) || (hour > 16 && < 23)) && (showing == 1){
					modal_stop();
					showing = 0;
					Last = "A2";
					A2 = 0;
				}
				//If it is after 11PM and A3 should be showing, or it is before 3AM and A3 should be showing and A3 was not the last combination used then turn on the modal.
				if (((hour > 23 && A3 == 1) && (Last != "A3")) || ((hour < 3) && (A3 == 1) && (Last != "A3"))){
					modal_display();
					showing = 1;
				}
				//If it is between 3AM and 6AM and a modal is showing turn off the modal and record the last variable.
				if ((hour >= 3 && < 6) && (showing == 1)){
					modal_stop();
					showing = 0;
					Last = "A3";
					A3 = 0;
				}
			};

			if (date == 14)
			{
				if ((hour >= 6 && hour <= 11) && (B1 == 1) && (Last != "B1"))
				{
					modal_display();
					showing = 1;
				}
				if ((hour == 12) && (showing == 1))
				{
					modal_stop();
					showing = 0;
					Last = "B1";
					B1 = 0;
				}
				if (((hour >= 13 && hour < 16) && (B2 == 1)) && (Last != "B2"))
				{
					modal_display();
					showing = 1;
				}
				if ((hour == 16) || (hour > 16 && < 23)) && (showing == 1){
					modal_stop();
					showing = 0;
					Last = "B2";
					B2 = 0;
				}
				if (((hour > 23 && A3 == 1) && (Last != "B3")) || ((hour < 3) && (B3 == 1) && (Last != "B3")))
				{
					modal_display();
					showing = 1;
				}
				if ((hour >= 3 && < 6) && (showing == 1))
				{
					modal_stop();
					showing = 0;
					Last = "B3";
					B3 = 0;
				}
			};
			if (date == 22)
			{
				if ((hour >= 6 && hour <= 11) && (C1 == 1) && (Last != "C1"))
				{
					modal_display();
					showing = 1;
				}
				if ((hour == 12) && (showing == 1))
				{
					modal_stop();
					showing = 0;
					Last = "C1";
					C1 = 0;
				}
				if (((hour >= 13 && hour < 16) && (C2 == 1)) && (Last != "C2"))
				{
					modal_display();
					showing = 1;
				}
				if ((hour == 16) || (hour > 16 && < 23)) && (showing == 1){
					modal_stop();
					showing = 0;
					Last = "C2";
					C2 = 0;
				}
				if (((hour > 23 && C3 == 1) && (Last != "C3")) || ((hour < 3) && (C3 == 1) && (Last != "C3")))
				{
					modal_display();
					showing = 1;
				}
				if ((hour >= 3 && < 6) && (showing == 1))
				{
					modal_stop();
					showing = 0;
					Last = "C3";
					C3 = 0;
				}
			}

			//Sanity check that if the date is not any expected in our combinations we should set all variables to 0 and run a modal_stop in case.
			if (date != 2 || date != 14 || date != 22)
			{
				showing = 0;
					A1 = 0;
					A2 = 0;
					A3 = 0;
					B1 = 0;
					B2 = 0;
					B3 = 0;
					C1 = 0;
					C2 = 0;
					C3 = 0;
					modal_stop();
			};
		}
	}
}
