using ConsoleDump;
using System;
using System.Text;


// When you compare two DateTime instances, only their ticks values are compared; their DateTimeKinds are ignored:

// TimeZoneInfo.Local returns the current local time zone:
TimeZoneInfo zone = TimeZoneInfo.Local;
zone.StandardName.Dump("StandardName (local)");
zone.DaylightName.Dump("DaylightName (local)");

DateTime dt1 = new DateTime(2019, 1, 1);
DateTime dt2 = new DateTime(2019, 6, 1);
Console.WriteLine(zone.IsDaylightSavingTime(dt1));
Console.WriteLine(zone.IsDaylightSavingTime(dt2));
Console.WriteLine(zone.GetUtcOffset(dt1));
Console.WriteLine(zone.GetUtcOffset(dt2));

// You can obtain a TimeZoneInfo for any of the world’s time zones by calling FindSystemTimeZoneById with the zone ID:
TimeZoneInfo wa = TimeZoneInfo.FindSystemTimeZoneById("W. Australia Standard Time");

Console.WriteLine(wa.Id);                   // W. Australia Standard Time
Console.WriteLine(wa.DisplayName);          // (GMT+08:00) Perth
Console.WriteLine(wa.BaseUtcOffset);        // 08:00:00
Console.WriteLine(wa.SupportsDaylightSavingTime);     // True
Console.WriteLine();

// The following returns all world timezones:
foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
    Console.WriteLine(z.Id);