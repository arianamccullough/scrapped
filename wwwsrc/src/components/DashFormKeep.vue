<template>
  <div class="col-6 dashformkeep">
    <form class="mt-5" @submit.prevent="addKeep">
      <div class="form-group">
        <label for="addKeep" class="formfont">Post a New Scrap</label>
        <input type="text" v-model="newKeep.name" name="name" class="form-control" placeholder="Name..." autofocus
          required>
        <input type="text" v-model="newKeep.description" name="description" class="form-control" placeholder="Description..."
          required>
        <input type="text" v-model="newKeep.img" name="img" class="form-control" placeholder="Image..." required>
        <label for="isPrivate">Keep Private? </label>
        <input v-model="newKeep.isPrivate" type="checkbox" id="isPrivate" name="isPrivate" true-value="1" false-value="0">
        <div class="row">
          <div class="col-12">
            <button type="submit" @click="addKeep" class="btn btn-success btn-sm">Add Scrap</button>
          </div>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
  export default {
    name: 'dashformkeep',
    data() {
      return {
        newKeep: {
          name: '',
          description: '',
          // location:'',
          img: '',
          isPrivate: 0
        },
      }
    },
    computed: {},
    methods: {
      addKeep() {
        this.$store.dispatch("addKeep", this.newKeep)
      }
    }
  }
</script>

<style>
  input[type="checkbox"] {
    width: 20px;
  }

  .formfont {
    font-weight: bold;
    font-size: 20px;
  }
</style>