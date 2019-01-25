import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 9000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 9000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},

    vaults: [],
    currentVault: {},

    allKeeps: [],
    myKeeps: [],
    keep: {},

    vaultKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setVaultKeeps(state, vaultKeeps) {
      state.vaultKeeps = vaultKeeps
    },

    setKeep(state, keep) {
      state.keep = keep
    },
    getKeeps(state, keeps) {
      state.allKeeps = keeps
    },
    getMyKeeps(state, myKeeps) {
      state.myKeeps = myKeeps
    },

    setCurrentVault(state, vault) {
      state.currentVault = vault
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
  },
  actions: {

    //vault things
    getVaults({ commit, dispatch }) {
      api.get('vaults/')
        .then(res => {
          commit("setVaults", res.data)
        })
    },
    addVault({ commit, dispatch }, vault) {
      api.post('vaults/', vault)
        .then(res => {
          dispatch("getVaults")
        })
    },
    deleteVault({ commit, dispatch }, id) {
      api.delete('vaults/' + id)
        .then(res => {

          dispatch("getVaults")
        })
    },

    //keep things
    getHomeKeeps({ commit, dispatch }, vaultKeeps) {
      api.get('keeps/')
        .then(res => {
          commit('getKeeps', res.data)
        })
    },
    getMyKeeps({ commit, dispatch }) {
      api.get('keeps/user')
        .then(res => {
          commit("getMyKeeps", res.data)
          dispatch("getMyKeeps", res.data)
        })
    },
    updateKeep({ commit, dispatch }, payload) {
      api.put('keeps/' + payload.id, payload)
        .then(res => {
          dispatch("getHomeKeeps")
        })
    },
    getKeep({ commit, dispatch }, keep) {
      api.get('keeps/' + keep)
        .then(res => {
          commit("setKeep", res.data)
        })
    },
    addKeep({ commit, dispatch }, newKeep) {
      api.post('keeps/', newKeep)
        .then(res => {
          dispatch("getMyKeeps", res.data)
          router.push({ name: 'dashboard' })
        })
    },
    deleteKeep({ commit, dispatch }, id) {
      api.delete('keeps/' + id)
        .then(res => {
          dispatch("getMyKeeps")
        })
    },

    //vaulty keepy things
    currentVault({ commit, dispatch }, vaultId) {
      api.get('vaultkeeps/' + vaultId)
        .then(res => {
          console.log(res.data)
          commit("setCurrentVault", vaultId)
          commit("setVaultKeeps", res.data)
        })
    },

    addVaultKeep({ commit, dispatch }, vaultKeep) {
      api.post('vaultkeeps/', vaultKeep)
        .then(res => {
          commit("setVaultKeeps", res.data)
        })
    },
    deleteVaultKeep({ commit, dispatch }, payload) {
      api.delete('vaultkeeps/' + payload.vaultId + '/' + payload.keepId)
        .then(res => {
          dispatch("currentVault", payload.vaultId)
        })
    },

    //auth things
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
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
    login({ commit, dispatch }, creds) {
      auth.post('/login', creds)
        .then(res => {
          commit('setUser', res.data)
          // router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('/logout')
        .then(res => {
          commit('setUser', {})
        })
    },
  }

})