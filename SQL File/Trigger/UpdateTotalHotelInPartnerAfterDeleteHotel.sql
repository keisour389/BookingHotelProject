--Update Total Hotel In Partner After Delete Hotel
CREATE TRIGGER UpdateTotalHotelInPartnerAfterDeleteHotel ON Hotel AFTER DELETE AS
BEGIN
	UPDATE Partners
	SET TotalHotel = TotalHotel - 1
	WHERE PartnerId IN(
		SELECT PartnerId
		FROM deleted d
		WHERE PartnerID = d.PartnerID --Lấy Partner vừa deleted
	)
END