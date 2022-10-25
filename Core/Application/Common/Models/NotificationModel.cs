using System;
namespace Core.Application.Common.Models;

public class EmailRequest
{
    public List<RecipientCustom> To { get; set; }
    public List<Recipient> Cc { get; set; }
    public List<Recipient> Bcc { get; set; }
    public List<Attachment> Attachments { get; set; }
    public Appointment Appointment { get; set; }
    public Recipient ReplayTo { get; set; }
    public string Subject { get; set; }
    public string HTMLContent { get; set; }
    public string TextContent { get; set; }
    public string HTMLTemplate { get; set; }
    public DateTime? SendAt { get; set; }
    public bool IsUrlTemplate { get; set; } = false;
    public bool IsCustomized { get; set; } = false;
    public bool IsInBackground { get; set; } = false;
}


public class RecipientCustom
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Data { get; set; }
}

public class Recipient
{
    public string Name { get; set; }
    public string Email { get; set; }
}

public class Appointment
{
    public string Summary { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
}

public class Attachment
{
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Data { get; set; } = default!;
    public string Url { get; set; } = default!;
}


public class EmailResponse
{
    public string RequestId { get; set; }
    public string JobId { get; set; }
    public string Message { get; set; }
    public string Status { get; set; }
}



