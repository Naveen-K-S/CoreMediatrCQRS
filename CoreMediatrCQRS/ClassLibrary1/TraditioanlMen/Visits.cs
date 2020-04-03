using System;
using System.Collections.Generic;
using System.Text;
using static ClassLibrary1.Men.Visit.FirstVisit;

namespace ClassLibrary1.TraditioanlMen
{
    public class Visits
    {

        public void BoyFriend(BoyFriend boyfriend)
        {

            if(IsHeYourDriver())
            {
                if(MoneyinWallet())
                {
                    PurchaseFancyDress();
                    PurchaseGoodGift();
                }
                
                MeetGF();
                ChildHoodFriends();
                CricketFriends();
            }
            
        }

        private bool MoneyinWallet()
        {
            throw new NotImplementedException();
        }

        private void CricketFriends()
        {
            throw new NotImplementedException();
        }

        private void MeetGF()
        {
            //Raise Event
            ChildHoodFriends();
            CricketFriends();
        }

        private void ChildHoodFriends()
        {
            throw new NotImplementedException();
        }

        private void PurchaseGoodGift()
        {
            throw new NotImplementedException();
        }

        private void PurchaseFancyDress()
        {
            throw new NotImplementedException();
        }

        private bool IsHeYourDriver()
        {
            return true;
        }

        private void RuleTobeYourBF()
        {
            throw new NotImplementedException();
        }
    }
}
