﻿using System;
using System.Linq;
using Ardalis.Specification;
using FrontDesk.Core.Aggregates;

namespace FrontDesk.Core.Specifications
{
  public class ScheduleForClinicAndDateWithAppointmentsSpec : Specification<Schedule>, ISingleResultSpecification
  {
    public ScheduleForClinicAndDateWithAppointmentsSpec(int clinicId, DateTime date)
    {
      Query
          .Include(nameof(Schedule.Appointments))
          .Where(schedule =>
              schedule.ClinicId == clinicId &&
              schedule.Appointments != null &&
              schedule.Appointments.Any(appointment => ((DateTime?)appointment.TimeRange.Start).Value.Date == ((DateTime?)date).Value.Date));
    }
  }
}