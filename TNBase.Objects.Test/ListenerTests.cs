using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TNBase.Objects.Test
{
    [TestClass]
    public class ListenerTests
    {
        private Listener CreateValidListener()
        {
            Listener listener = new Listener();

            listener.Title = "Mr";
            listener.Forename = "Ted";
            listener.Surname = "Baker";
            listener.Addr1 = "29 Baker Street";
            listener.Addr2 = "";
            listener.Postcode = "N193HH";
            listener.Birthday = DateTime.Parse("01/01/2015");
            listener.County = "Londonshire";
            listener.inOutRecords = new InOutRecords();
            listener.MemStickPlayer = true;
            listener.LastIn = DateTime.Now;
            listener.LastOut = null;
            listener.Joined = DateTime.Parse("01/01/2015");
            listener.Magazine = false;
            listener.Status = ListenerStates.ACTIVE;
            listener.DeletedDate = DateTime.Parse("01/01/2015");
            listener.Telephone = "01234567890";
            listener.Town = "London";
            listener.Wallet = 0;

            return listener;
        }

        [TestMethod]
        public void Listener_DaysBeforeBirthday()
        {
            DateTime dateTime = DateTime.Now.AddDays(5);
            Assert.AreEqual(5, Listener.DaysUntilBirthday(dateTime));

            dateTime = DateTime.Now.AddDays(67);
            Assert.AreEqual(67, Listener.DaysUntilBirthday(dateTime));
        }

        [TestMethod]
        public void Listener_BirthdayThisYear()
        {
            Listener dummy = CreateValidListener();
            DateTime birthdayThisYear = dummy.BirthdayThisYear();

            Assert.AreEqual(DateTime.Now.Year, birthdayThisYear.Year);
            Assert.AreEqual(dummy.Birthday.Value.Month, birthdayThisYear.Month);
            Assert.AreEqual(dummy.Birthday.Value.Day, birthdayThisYear.Day);
        }

        [TestMethod]
        public void Listener_PauseTest()
        {
            Listener dummy = CreateValidListener();
            dummy.Status = ListenerStates.ACTIVE;

            // Pause with a never end date.
            DateTime startDate = DateTime.Now;
            dummy.Pause(startDate);

            Assert.AreEqual(ListenerStates.PAUSED, dummy.Status);
            Assert.AreEqual(startDate.DayOfYear, dummy.GetStoppedDate().DayOfYear);
            // Not expecting a resume date.
            Assert.AreEqual(null, dummy.GetResumeDate());

            // Now pause them with an end date (+10 days).
            DateTime endDate = startDate.AddDays(10);
            dummy.Pause(startDate, endDate);

            Assert.AreEqual(ListenerStates.PAUSED, dummy.Status);
            Assert.AreEqual(startDate.DayOfYear, dummy.GetStoppedDate().DayOfYear);
            // Not expecting a resume date.
            Assert.AreEqual(endDate.DayOfYear, dummy.GetResumeDate().Value.DayOfYear);
        }

        [TestMethod]
        public void Listener_ResumeTest()
        {
            Listener dummy = CreateValidListener();
            dummy.Pause(DateTime.Now);
            dummy.Resume();

            Assert.AreEqual(ListenerStates.ACTIVE, dummy.Status);
            Assert.IsTrue(string.IsNullOrEmpty(dummy.StatusInfo), "Expected empty or null status info string.");
        }

        [TestMethod]
        [ExpectedException(typeof(ListenerStateChangeException))]
        public void Listener_ResumeActive()
        {
            Listener dummy = CreateValidListener();
            dummy.Status = ListenerStates.ACTIVE;

            dummy.Resume();
        }

        [TestMethod]
        [ExpectedException(typeof(ListenerStateChangeException))]
        public void Listener_PauseDeletedListener()
        {
            Listener dummy = CreateValidListener();
            dummy.Status = ListenerStates.DELETED;

            dummy.Pause(DateTime.Now);
        }

        [TestMethod]
        public void GetNiceName_ReturnsName_WhenNoTitle()
        {
            var listener = new Listener
            {
                Title = "",
                Forename = "Bob",
                Surname = "Builder"
            };

            var result = listener.GetNiceName();

            Assert.AreEqual("Bob Builder", result);
        }

        [TestMethod]
        public void GetNiceName_ReturnsNameWithTitle_WhenTitleProvided()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder"
            };

            var result = listener.GetNiceName();

            Assert.AreEqual("Mr. Bob Builder", result);
        }

        [TestMethod]
        public void FormatListenerData_ReturnsOnlyListenerNiceName_WhenNoAddress()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder"
            };

            var result = listener.FormatListenerData();

            Assert.AreEqual("Mr. Bob Builder", result);
        }

        [TestMethod]
        public void FormatListenerData_ReturnsFirstLineAddressInSecondLine_WhenHasFirstLineAddress()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder",
                Addr1 = "Test House"
            };

            var result = listener.FormatListenerData();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.AreEqual("Test House", lines[1]);
        }

        [TestMethod]
        public void FormatListenerData_ReturnsSecondLineAddressInSecondLine_WhenHasSecondLineAddress()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder",
                Addr1 = "Test House",
                Addr2 = "Test Street"
            };

            var result = listener.FormatListenerData();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.AreEqual("Test House, Test Street", lines[1]);
        }

        [TestMethod]
        public void FormatListenerData_ReturnsTownInThirdLine_WhenHasTown()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder",
                Addr1 = "Test House",
                Addr2 = "Test Street",
                Town = "Test Town"
            };

            var result = listener.FormatListenerData();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.AreEqual("Test Town", lines[2]);
        }

        [TestMethod]
        public void FormatListenerData_ReturnsCountyInThirdLine_WhenHasCounty()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder",
                Addr1 = "Test House",
                Addr2 = "Test Street",
                Town = "Test Town",
                County = "Test County"
            };

            var result = listener.FormatListenerData();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.AreEqual("Test Town, Test County", lines[2]);
        }

        [TestMethod]
        public void FormatListenerData_ReturnsPostcodeInFourthLine_WhenHasPostcode()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder",
                Addr1 = "Test House",
                Addr2 = "Test Street",
                Town = "Test Town",
                County = "Test County",
                Postcode = "Test Postcode"
            };

            var result = listener.FormatListenerData();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.AreEqual("Test Postcode", lines[3]);
        }

        [TestMethod]
        public void DeletePersonalData_SetsStatusToDeleted()
        {
            var listener = new Listener
            {
                Status = ListenerStates.ACTIVE
            };

            listener.DeletePersonalData();

            Assert.AreEqual(ListenerStates.DELETED, listener.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(ListenerStateChangeException))]
        public void DeletePersonalData_ThrowsException_WhenPlayerIsNotReturned()
        {
            var listener = new Listener
            {
                MemStickPlayer = true
            };

            listener.DeletePersonalData();
        }

        [TestMethod]
        public void DeletePersonalData_ClearsListenersName()
        {
            var listener = new Listener
            {
                Title = "Title",
                Forename = "Forename",
                Surname = "Surname"
            };

            listener.DeletePersonalData();

            Assert.AreEqual("N/A", listener.Title);
            Assert.AreEqual("Deleted", listener.Forename);
            Assert.AreEqual("Deleted", listener.Surname);
        }

        [TestMethod]
        public void DeletePersonalData_ClearsListenersAddress()
        {
            var listener = new Listener
            {
                Addr1 = "Address1",
                Addr2 = "Address2",
                Town = "Town",
                County = "County",
                Postcode = "Postcode",
            };

            listener.DeletePersonalData();

            Assert.IsNull(listener.Addr1);
            Assert.IsNull(listener.Addr2);
            Assert.IsNull(listener.Town);
            Assert.IsNull(listener.County);
            Assert.IsNull(listener.Postcode);
        }

        [TestMethod]
        public void DeletePersonalData_ClearsListenersInfo()
        {
            var listener = new Listener
            {
                Telephone = "123456789",
                Joined = DateTime.UtcNow,
                Birthday = DateTime.UtcNow,
                Info = "Test Info"
            };

            listener.DeletePersonalData();

            Assert.IsNull(listener.Telephone);
            Assert.IsNull(listener.Joined);
            Assert.IsNull(listener.Birthday);
            Assert.IsNull(listener.Info);
        }

        [TestMethod]
        public void DeletePersonalData_SetsCorrectDeletedDate()
        {
            var listener = new Listener();

            var before = DateTime.UtcNow;
            listener.DeletePersonalData();
            var after = DateTime.UtcNow;

            Assert.IsTrue(before <= listener.DeletedDate, "Date is greater or equal to before");
            Assert.IsTrue(after >= listener.DeletedDate, "Date is less or equal to after");
        }
    }
}
