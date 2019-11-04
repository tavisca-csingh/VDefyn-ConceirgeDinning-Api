using ConceirgeDiningDAL.Models;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.ServicesImplementation.BookingTable;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDining.Middleware.BookingTable
{
    
    public class CancellInitialiser
    {
        private Booking booking;
        CancellResponse cancellResponse;
        sql12310325Context sql12310325Context;
        public CancellInitialiser(Booking booking)
        {
            this.booking = booking;
            sql12310325Context = new sql12310325Context();
            cancellResponse = new CancellResponse();
        }
        public CancellResponse Validation(int bookingID,long pointBalance)
        {
            
            CancellValidator cancellValidator = new CancellValidator();
            cancellResponse.Error = new List<string>();
            cancellResponse.BookingId = bookingID;
            if (!cancellValidator.CheckBookingId(booking))
            {
                
                cancellResponse.Error.Add("Booking Id: "+bookingID+" is invalid");
                cancellResponse.Status = "Invalid Booking ID";
                cancellResponse.UpdatedPointBalance = pointBalance;
            }
            else if(!cancellValidator.CheckCancellStatus(booking))
            {
                cancellResponse.Error.Add("Booking Id: " + bookingID + " is already cancelled");
                cancellResponse.Status = "Booking ID already cancelled";
                cancellResponse.UpdatedPointBalance = pointBalance;
            }
            else
            {
                cancellResponse.Status = "Cancellation Possible";
            }

            return cancellResponse;
        }
        public CancellResponse Start(long pointBalance,long totalPointPrice)
        {
            CancellInitiator cancellInitiator = new CancellInitiator(booking);
            if(booking.Status== "BookingInitiated")
            {
                cancellInitiator.DeleteEntryInBookingProcess();
                cancellInitiator.ChangeBookingStatus();
                cancellInitiator.ChangeSeatsStatus();
                cancellResponse.Status = "Cancelled";
                cancellResponse.Error = null;
                cancellResponse.UpdatedPointBalance=pointBalance;
            }
            else if(booking.Status=="Booked")
            {
                cancellInitiator.ChangeBookingStatus();
                cancellInitiator.ChangeSeatsStatus();
                cancellResponse.Status = "Cancelled";
                cancellResponse.Error = null;
                cancellResponse.UpdatedPointBalance = pointBalance + totalPointPrice;
            }
            return cancellResponse;
        }
    }
}
