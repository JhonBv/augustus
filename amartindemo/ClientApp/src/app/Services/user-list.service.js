"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.UserListService = void 0;
var UserListService = /** @class */ (function () {
    function UserListService(http, root) {
        this.http = http;
        this.root = root;
    }
    UserListService.prototype.getUserList = function () {
        var endPoint = 'users/list';
        return this.http.get(this.root.apiRootUrl + endPoint);
    };
    return UserListService;
}());
exports.UserListService = UserListService;
//# sourceMappingURL=user-list.service.js.map