import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import MyKeep from './views/MyKeep.vue'
// @ts-ignore
import MyVault from './views/MyVault.vue'
// @ts-ignore
import Dashboard from './views/Dashboard.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },

    {
      path: '/mykeep',
      name: 'mykeep',
      component: MyKeep
    },
    {
      path: '/myvault',
      name: 'myvault',
      component: MyVault
    },
    {
      path: '/dashboard',
      name: 'dashboard',
      component: Dashboard
    }
  ]
})
