# DarkSteam
Long-long ago there was a project, that allowed to download Steam versions of games. It is long-dead now, but the code may still be useful to someone.

Essentially it is a library written on PHP and using MySQL and Steam API to store and retrieve data, respectively.

## Usage
### Setup
Essentially all you need to do is place the files `config.php` (created from `config.sample.php`), `index.php` and `api` subfolder and you're golden. Well, almost, since you need to create database first.

For convinience, there is a `structure_sql.sql` file to create related tables. To get you started there is also `data_sql.sql` which also has data as seen [here](http://simbiat.net/DarkSteam).

Then setup database connection in `config.sample.php`, rename it to `config.php` and you will have a working site.

### Acquiring new data
Of course this all will be pointless, unless you can get new data. SInce DarkSteam was based around vBulletin 4 some of its CRON features were used.

`includes\cron` subfolder has the appropriate files. Note, that they may not work without vBulletin 4 itself and also requires .acf files from Steam Games.

### Client
DarkSteam service used a user-side client to download data (from SFTP, until torrents migration, which killed the service). Code for it can be found in `client_code` subfolder. Essentially it is a webbrowser to show the `api` subfolder pages, authenticate users and download files from SFTP.

# Important notice
Please, note, that this project is not supported at all so no bugs will be fixed, if found and reported. Only update to be done is adding comments to portions of the code.