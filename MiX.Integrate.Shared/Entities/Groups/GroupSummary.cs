﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Shared.Entities.Groups
{
	public class GroupSummary
	{
		public GroupSummary()
		{
			this.SubGroups = new List<GroupSummary>();
		}

		public GroupSummary(long groupId, string name, GroupType type) : this()
		{
			GroupId = groupId;
			Name = name;
			Type = type;
		}
		public long GroupId { get; set; }
		public string Name { get; set; }
		public GroupType Type { get; set; }
		public List<GroupSummary> SubGroups { get; set; }
	}
}
