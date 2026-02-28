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

TNBase application is developed using Visual Studio 2022 or later. A free Community Edition is
fully sufficient for development and is available to download on Microsoft website.
The project targets .NET 8, so ensure you have the .NET 8 SDK installed.

There is no need for any additional configuration to open and run the solution.

Please ensure to create a new branch when making any changes. Never commit any changes directly to `master` branch.
Once required modifications are complete and fully tested, please create a Pull Request on GitHub website.
This will trigger an automated build pipeline to ensure that the application builds successfully and all unit tests pass.

### Release

The release of TNBase application is fully automated using GitHub Actions. To create a new release:

1. **Update release notes** — Add a new version section at the top of `Release Notes.txt` with the version number on its own line, followed by the changes:
   ```
   1.8.3
   - Description of first change
   - Description of second change
   ```
   The pipeline will fail if release notes are missing for the tagged version.

2. **Commit and push** the updated `Release Notes.txt` to the `master` branch.

3. **Create a version tag** on the `master` branch:
   ```
   git tag v1.8.3
   ```
   The value represents the new version using the pattern `major.minor.patch`.

4. **Push the tag** to trigger the release pipeline:
   ```
   git push origin --tags
   ```

This will trigger the pipeline that can be observed in the Actions tab on GitHub. After a successful run, a new Release will be available at https://github.com/achrisdale/TNBase/releases

The version number from the tag is automatically applied to all project assemblies via `Directory.Build.props` and to the MSI installer.

> **Note:** Local builds will always show version `1.0.0` as defined in `Directory.Build.props`. The correct version is only applied during CI builds (PRs and releases). This is expected and does not affect release builds.
