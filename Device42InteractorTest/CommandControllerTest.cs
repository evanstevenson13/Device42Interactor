

using Device42Interactor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Device42InteractorTest{
    [TestClass]
    public class CommandControllerTest{
        [TestMethod]
        public void DevicesReturned(){
            D42Commands.Initialize("https://oatestdata.azurewebsites.net", "80", "admin", "password");
            D42DeviceList devices = D42Commands.GetAllDevices();
            List<string> expectedDevices = new List<string>(){"320", "323p1", "d250", "d313p1"};

            Assert.AreEqual(expectedDevices.Count, devices.devices.Count);

            foreach(D42Device device in devices.devices){
                Assert.IsTrue(expectedDevices.Contains(device.name));
            }
        }
    }
}
