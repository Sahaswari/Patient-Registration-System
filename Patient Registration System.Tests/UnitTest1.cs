namespace Patient_Registration_System.Tests
{
    public class PayementVMTests
    {
        [Fact]
        public void RefreshPatients_LoadsPatientsFromDatabase()
        {
            
            var viewModel = new PayementVM();
            var mockDb = new Mock<DataContext>();
            var patientsFromDb = new List<Patient>
            {
                new Patient { PatientId = 1, PatientFirstName = "John", PatientPayment = 100 },
                new Patient { PatientId = 2, PatientFirstName = "Jane", PatientPayment = 200 }
            };
            mockDb.Setup(db => db.patients.ToList()).Returns(patientsFromDb);

            
            viewModel.RefreshPatients(mockDb.Object);

            
            Assert.Equal(2, viewModel.Patients.Count);
            Assert.Equal(1, viewModel.Patients[0].PatientId);
            Assert.Equal("John", viewModel.Patients[0].PatientFirstName);
            Assert.Equal(100, viewModel.Patients[0].PatientPayment);
            Assert.Equal(2, viewModel.Patients[1].PatientId);
            Assert.Equal("Jane", viewModel.Patients[1].PatientFirstName);
            Assert.Equal(200, viewModel.Patients[1].PatientPayment);
        }
    }
}