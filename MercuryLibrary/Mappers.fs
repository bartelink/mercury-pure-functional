module MercuryLibrary.Mappers

open System
open MercuryLibrary.Models

let toWhoisResponse (domain: string) (whoisRecord: WhoisRecord) =
    let now = DateTime.UtcNow

    let createdDate =
        match DateTime.TryParse whoisRecord.createdDate with
        | _, date -> date

    let updatedDate =
        match DateTime.TryParse whoisRecord.updatedDate with
        | _, date -> date

    let expiresDate =
        match DateTime.TryParse whoisRecord.expiresDate with
        | _, date -> date

    let auditCreatedDate =
        match DateTime.TryParse whoisRecord.audit.createdDate with
        | _, date -> date

    let auditUpdatedDate =
        match DateTime.TryParse whoisRecord.audit.updatedDate with
        | _, date -> date

    { Domain = domain
      DomainAgeInDays = BusinessLogic.differenceInDays createdDate now
      DomainLastUpdatedInDays = BusinessLogic.differenceInDays updatedDate now
      DomainExpirationInDays = BusinessLogic.differenceInDays now expiresDate
      AuditCreated = auditCreatedDate
      AuditUpdated = auditUpdatedDate }