--Update Total Hotel In Partner After Insert Hotel
CREATE TRIGGER UpdateTotalHotelInPartnerAfterInsertHotel ON Hotel AFTER INSERT AS
BEGIN
	UPDATE Partners
	SET TotalHotel = TotalHotel + 1
	WHERE PartnerId IN(
		SELECT PartnerId
		FROM inserted i
		WHERE PartnerID = i.PartnerID --Lấy Partner vừa inserted
	)
END