using System;
using System.Collections.Generic;

namespace iBosAssesmentAPI.Models;

public partial class TblEmployeeAttendance
{
    public int? EmployeeId { get; set; }

    public string? AttendanceDate { get; set; }

    public int? IsPresent { get; set; }

    public int? IsAbsent { get; set; }

    public int? IsOffday { get; set; }
}
