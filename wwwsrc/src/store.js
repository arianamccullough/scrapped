import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 8000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 8000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    vault: {},
    vaults: [],
    keep: {},
    keeps: [],
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setVault(state, vault) {
      state.vault = vault
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setKeep(state, keep) {
      state.keep = keep
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    }

  },
  actions: {

    //USER LOGIN/REGISTER/AUTH
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('/logout')
        .then(res => {
          commit('setUser', {})
          console.log('User logged out')
          router.push({ name: 'home' })
        })
    },

    //Vault Things
    getVaults({ commit, dispatch }) {
      api.get('vaults')
        .then(res => {
          commit('setVaults', res.data)
        })
    },
    addVault({ commit, dispatch }, vaultData) {
      api.post('vaults', vaultData)
        .then(v => {
          dispatch('getVaults')
        })
        .catch(e => {
          console.log('addvault failed')
        })
    },
    deleteVault({ commit, dispatch }, vaultId) {
      api.delete('vaults/' + vaultId)
        .then(res => {
          dispatch('getVaults')
        })
    },
    //Keep Things
    getAllKeeps({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },
    addKeep({ commit, dispatch }, keepData) {
      api.post('keeps', keepData)
        .then(v => {
          dispatch('getAllKeeps')
        })
        .catch(e => {
          console.log('addkeep failed')
        })
    },
    deleteKeep({ commit, dispatch }, keepId) {
      api.delete('keeps/' + keepId)
        .then(res => {
          dispatch('getAllKeeps')
        })
    },

    //My Vault/Keep
    // Get all keeps with certain vaultId
    getMyKeeps({ commit, dispatch }, vaultId) {
      api.get('/keeps/' + vaultId)
        .then(res => {
          commit('setKeeps', res.data)
        })
    },
  }
})