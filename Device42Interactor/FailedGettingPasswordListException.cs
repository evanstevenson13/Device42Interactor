using System;
using System.Runtime.Serialization;

namespace Device42Interactor {
    [Serializable]
    internal class FailedGettingPasswordListException : Exception {
        public FailedGettingPasswordListException() {
        }

        public FailedGettingPasswordListException(string message) : base(message) {
        }

        public FailedGettingPasswordListException(string message,Exception innerException) : base(message,innerException) {
        }

        protected FailedGettingPasswordListException(SerializationInfo info,StreamingContext context) : base(info,context) {
        }
    }
}