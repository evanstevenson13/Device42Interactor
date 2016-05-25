

using Device42Interactor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Device42InteractorTest{
    [TestClass]
    public class D42CommandsTest{

        [TestMethod]
        [ExpectedException(typeof(InvalidInitializeException))]
        public void InitializeNoServerAddress(){
            D42Commands.Initialize(string.Empty, "80", "admin", "password");
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidInitializeException))]
        public void InitializeNoUsername(){
            D42Commands.Initialize("https://oatestdata.azurewebsites.net", "80", string.Empty, "password");
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidInitializeException))]
        public void InitializeNoPassword(){
            D42Commands.Initialize("https://oatestdata.azurewebsites.net", "80", "Username", string.Empty);
        }


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
