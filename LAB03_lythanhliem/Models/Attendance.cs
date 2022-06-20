public Course course { get; set; }

[key]
[column(order = 1)]
public int courseId { get; set; }

public ApplicationUser Attendee { get; set; }

[key]
[column(order = 2]
public string AttendeeId { get; set; }
