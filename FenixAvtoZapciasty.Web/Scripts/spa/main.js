'use strict'
console.log(213)
var app = angular.module('myApp', ['ui.router'])
	.config(function ($stateProvider, $urlRouterProvider) {
		$stateProvider
			.state('app', {
				url: '/',
				views: {
					'navbar': {
						templateUrl: 'Scripts/spa/navbar/navbar.html',
					},
					'menu': {
						templateUrl: 'Scripts/spa/menu/menu.html',
					},
					'content': {
						templateUrl: 'Scripts/spa/content/content.html',
						//controller: 'contentController'
					},
					'footer': {
						templateUrl: 'Scripts/spa/footer/footer.html',
					}
				}
			})
			.state('app.about', {
				url: 'about',
				views: {
					'content@': {
						templateUrl: 'assets/views/about.html',
						controller: 'formController'
					}
				}
			})
			.state('app.addpage', {
				url: 'addpage',
				views: {
					'content@': {
						templateUrl: 'assets/views/addpage.html',
						controller: 'formController'
					}
				}
			})
			.state('app.info', {
				url: 'info/:id',
				views: {
					'content@': {
						templateUrl: 'assets/views/info.html',
						controller: 'infoController'
					}
				}
			});

		$urlRouterProvider.otherwise('/');

	});