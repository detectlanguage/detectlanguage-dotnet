# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).


## v2.0.0

### Changed
- Switched to v3 API which uses updated language detection model
- ⚠️ Added `DetectResult` field `score`, removed `confidence` and `reliable`
- Renamed `GetUserStatusAsync` to `GetAccountStatusAsync`
- Updated `Newtonsoft.Json` dependency to `13.0.3`
