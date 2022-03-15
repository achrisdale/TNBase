# Developer Notes

### Scaning process

1. Listeners are scanned (frmScanIn) along with a count of how many times each wallet has been scanned
1. Loops through the wallet numbers that have been scanned in
1. The in8 field is set to the number of new wallets that have been
1. The stock is incremented by however many wallets have been scanned in
1. If the new stock is over >3 we show a warning
1. If the listener is active we take one away from the stock (as we will be sending a wallet out anyway and the scanned in wallet will go straight into an out pile). The last out date is set to the current time if this happens
1. The last in is updated to the current time
1. After all scanned in wallets are processed, for all listeners, we set in1 = in2, in2 = in3, ... and in8=0 and do the same for the out columns
1. If they are active and a wallet as scanned in (now in in7), we set out8 = 1
1. frmScanOutInitial, lists listeners that are active and in7 = 0 and stock > 0 (basically all active listeners with stock that where not scanned in)
1. frmScanOut, wallets are scanned out along with a count of how many times
1. At the end of this we loop through all wallets scanned out, set out8 to the count of how many times that wallet was scanned
1. Last out is set to the current time
1. The stock is set to stock - (number of times scanned out)

### Database Check

1. sqlite3 Listeners.s3db "PRAGMA integrity_check"

### Local Development

TNBase application is developed using Visual Studio 2019. A free Community Edition is
fully sufficient for development and is available to download on Microsoft website.

There is no need for any addition configuration to open and run the solution.

Please ensure to create a new branch when making any changes. Never ever commit any changes directly to `master` branch.
Once required modifications are complete and fully tested, please create a Pull Reques on GitHub website.
This will trigger an automated build pipeline to ensure that the application builds successfully and all unit tests passes.

### Release

The release of TNBase application is fully automated using GitHub Actions.
Simply add release notes to the `Release Notes.txt` file following the existig format. 
Any new version in the release notes will automatically trigger the release process as follows:

- Adds a new git tag and creates a new release under https://github.com/achrisdale/TNBase/releases when built on master branch, or
- Uploads installation file as a build artefact when built on any other branch, i.e. pull request

