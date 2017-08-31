﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Shared.Entities.Messages
{
	public class SendMessageResult
	{
		public bool Result { get; set; }
		public int MessageId { get; set; }
		public bool VehicleHasRequiredDevice { get; set; }
		public bool IsMessageToUnitLimitReached { get; set; }
		public SendMessageResult() { }
	}
}
