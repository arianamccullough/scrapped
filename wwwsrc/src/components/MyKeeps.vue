<template>
  <div class="myKeeps">
    <div class="row">
      <div class="col-12">
        <h3>My Scraps</h3>
      </div>
      <div class="col-3 card p-3 m-3" v-for="keeps in myKeeps">
        <h5 class="card-font"><b>{{keeps.name}}</b></h5>
        <img :src="keeps.img">
        <p class="card-font"><i>{{keeps.description}}</i></p>
        <div>
          <button class="btn btn-info btn-sm dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown">Paste
            Scrap to...</button>
          <div class="dropdown-menu">
            <div v-for="vault in vaults">
              <h6 class="dropdown-item " @click="addVaultKeep(vault, keeps, user.id)">{{vault.name}}</h6>
            </div>
          </div>
        </div>
        <button class="btn btn-danger btn-sm" @click="deleteKeep(keeps.id)">Peel From Book</button>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'myKeeps',
    mounted() {
      this.$store.dispatch("getMyKeeps")
    },
    data() {
      return {
      }
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      vault() {
        return this.$store.state.vault
      },
      vaults() {
        return this.$store.state.vaults
      },
      myKeeps() {
        return this.$store.state.myKeeps
      },
    },
    methods: {
      deleteKeep(id) {
        this.$store.dispatch("deleteKeep", id)
      },
      addVaultKeep(vault, keep, userid) {
        let vaultKeep = {
          vaultId: vault.id,
          keepId: keep.id,
          userId: userid,
        }
        keep.keeps++
        this.$store.dispatch("updateKeep", keep)
        this.$store.dispatch("addVaultKeep", vaultKeep)
      }
    }
  }
</script>

<style>
  img {
    width: 100%;
    height: 150px;
  }

  .card-font {
    color: black;
  }

  .card {
    outline: 1px solid black;
  }

  .card:hover {
    outline: 1px solid black;
    box-shadow: 3px 3px rgb(185, 185, 185);
  }
</style>