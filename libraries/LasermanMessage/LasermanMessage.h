#ifndef _LASERMAN_MESSAGE_h
#define _LASERMAN_MESSAGE_h

#include <stdint.h>

enum MessageType : uint8_t {
	SetSpeed		= 0,
	SetBacklashX	= 1,
	SetBacklashY	= 2,
	ResetMotors		= 3,
	AddTarget		= 4,
	EndTrajectory	= 5,
	ClearBuffer		= 6,
	Echo			= 7,
	TargetReached	= 8,
	DebugInfo		= 9,
};

struct SetSpeedData {
	float		speed;

private:
	uint8_t		padder[1];
};

struct SetBacklashData {
	uint16_t	backlash;

private:
	uint8_t		padder[3];
};

struct TargetData {
	uint16_t	position[2];
	uint8_t		intensity;
};

union MessageData {
	SetSpeedData	speedData;
	SetBacklashData	backlashData;
	TargetData		targetData;
};

struct LasermanMessage {
	MessageData	data;
	MessageType	type;
};

#endif
