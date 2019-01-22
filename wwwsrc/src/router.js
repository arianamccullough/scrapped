import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import OneKeep from './views/OneKeep.vue'
// @ts-ignore
import OneVault from './views/OneVault.vue'
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
      path: '/keeps/:keepId',
      name: 'onekeep',
      props: true,
      component: OneKeep
    },
    {
      path: '/vaults/:vaultId',
      name: 'onevault',
      props: true,
      component: OneVault
    },
    {
      path: '/dashboard',
      name: 'dashboard',
      component: Dashboard
    }
  ]
})
