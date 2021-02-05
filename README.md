# AttendanceClock
WinForm app for managing attendence, for users (workers) and admin reports.<br>

App architecture:<br>
App does NOT use ASP Identity for users.<br>
Data abstraction layer communicates with Db via Stored procedures. SP files added to this repository.<br>
Password handling and hashing is done explicitly via custom static class.<br>

App allows:<br>
Register new user.<br>
User sign in/out.<br>
Active signed-in time clock when signed in.<br>
Signed in time summary for users on sign out.<br>
Admin reports by date/user for admins.<br>
