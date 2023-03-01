using System;
using System.Collections;
using System.Collections.Generic;

public static class PublicVars
{
    public enum Flag
    {
        // Clue flags
        DoorIsLocked, FoundDoorKey,
        SafeIsLocked, FoundSafeCode,
        FireplaceIsStrange, FoundBlueprints,
        RoomIsBlocked, FoundHammer,
        DrawerIsLocked, FoundDrawerKey,
        GhostIsSad, FoundGhostJournal
    }

    static List<Flag> _setFlags;
    static int _newFlags;

    static PublicVars()
    {
        _setFlags = new List<Flag>();
        _newFlags = 0;
    }

    public static bool CheckFlag(Flag flag)
    {
        return _setFlags.Contains(flag);
    }

    public static bool SetFlag(Flag flag)
    {
        bool already_set = CheckFlag(flag);
        if (!already_set)
        {
            _setFlags.Add(flag);
            _newFlags++;
        }
        return already_set;
    }

    public static int GetNewFlagCount()
    {
        return _newFlags;
    }

    public static void ResetNewFlagCount()
    {
        _newFlags = 0;
    }
}
