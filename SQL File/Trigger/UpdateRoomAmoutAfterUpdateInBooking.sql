--Update Room Amout After Update In Booking
CREATE TRIGGER UpdateRoomAmoutAfterUpdateInBooking ON BookingDetails AFTER UPDATE AS
BEGIN
	UPDATE RoomOfHotel
	SET RoomAmount = RoomAmount
	--Số sau khi được sửa
	- (
		SELECT NumberOfNights
		FROM inserted i
		WHERE i.HotelID = RoomOfHotel.HotelID  AND i.RoomID = RoomOfHotel.RoomID
	)
	--Số sau khi được sửa
	+ (
		SELECT NumberOfNights
		FROM deleted d
		WHERE d.HotelID = RoomOfHotel.HotelID  AND d.RoomID = RoomOfHotel.RoomID
	)
	--Join với bảng vừa update
	FROM RoomOfHotel
	JOIN inserted ON RoomOfHotel.HotelID = inserted.HotelID AND RoomOfHotel.RoomID = inserted.RoomID
END